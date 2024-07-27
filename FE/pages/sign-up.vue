<script setup lang="ts">
import type { FormSubmitEvent } from "#ui/types";
import useVuelidate from "@vuelidate/core";
import {
  email,
  helpers,
  minLength,
  required,
  sameAs,
} from "@vuelidate/validators";
const client = useSupabaseClient();
const err = ref("");
const isOpen = ref(true);
const pushHome = () => {
  return navigateTo("/");
};

 const login = async (_prov: any) => {
    const { data, error } = await client.auth.signInWithOAuth({
      provider: "google",
      options: {
        queryParams: {
          access_type: "offline",
          prompt: "consent",
        },
      },
    });
  };

const form = reactive({
  email: "",
  password: "",
  confirmPassword: "",
});

const v = useVuelidate(
  {
    email: {
      required: helpers.withMessage("Email is required", required),
      email: helpers.withMessage("Invalid email format", email),
    },
    password: {
      required: helpers.withMessage("The password field is required", required),
      minLength: minLength(6),
      containsPassword: helpers.withMessage(
        () =>
          `The password requires an uppercase, lowercase, number and special character`,
        (value: string) =>
          /(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*-_])/.test(value)
      ),
    },
    confirmPassword: {
      required: helpers.withMessage(
        "The password confirmation field is required",
        required
      ),
      sameAs: helpers.withMessage(
        "Passwords don't match",
        sameAs(computed(() => form.password))
      ),
    },
  },
  form
);

function validateWithVuelidate() {
  v.value.$touch();
  return v.value.$errors.map((error) => ({
    path: error.$propertyPath,
    message: error.$message as string,
  }));
}

defineExpose({
  validate: async () => await v.value.validate(),
});

watch(form, validateWithVuelidate, { deep: true });
async function signUpWithEmail() {
  // for type fix and safety
  if (!form.email || !form.password) return;
  const { data, error } = await client.auth.signUp({
    email: form.email,
    password: form.password,
  });
  if (error) {
    err.value = error.message;
  }
}

async function onSubmit(event: FormSubmitEvent<any>) {
  // Do something with data
  signUpWithEmail();
  return navigateTo("/");
}
</script>

<template>
  <div class="flex items-center justify-center h-screen p-4 ">
    <UCard
      :ui="{
        ring: '',
        divide: 'divide-y divide-gray-100 dark:divide-gray-700',
      }"
    >
      <template #header>
        <div class="flex items-center justify-center relative">
          <ULink @click="pushHome" class="absolute left-0 top-1">
            <UIcon name="i-heroicons-arrow-left" size="24" />
          </ULink>
          <h1 class="text-center">Sign Up</h1>
        </div>
      </template>

      <UContainer>
        <div class="mb-4">
              <UButton
                @click="login('google')"
                type="button"
                size="sm"
                class="flex items-center w-44 justify-center"
              >
                <UIcon name="flat-color-icons:google" dynamic size="20" />
                <span> Google</span>
              </UButton>
            </div>
        <UForm
          :state="form"
          :validate="validateWithVuelidate"
          class="space-y-4"
          @submit="onSubmit"
        >

          <UFormGroup label="Email" name="email">
            <UInput v-model="form.email" type="email" />
          </UFormGroup>
          <UFormGroup label="Password" name="password">
            <UInput v-model="form.password" type="password" />
          </UFormGroup>
          <UFormGroup label="Confirm Password" name="confirmPassword">
            <UInput v-model="form.confirmPassword" type="password" />
          </UFormGroup>
          <UButton
            type="submit"
            class="w-full flex items-center justify-center"
          >
            Sign Up
          </UButton>
          <div v-if="err" class="text-red-500 text-center text-xs">
            {{ err }}
          </div>
        </UForm>
      </UContainer>
    </UCard>
  </div>
</template>