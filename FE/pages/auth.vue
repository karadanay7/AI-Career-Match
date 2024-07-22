<template>
    <div>
      <UModal v-model="isOpen">
        <UCard
          :ui="{
            ring: '',
            divide: 'divide-y divide-gray-100 dark:divide-gray-800',
          }"
        >
          <template #header>
            <div class="flex items-center justify-center relative">
              <ULink @click="pushHome" class="absolute left-0 top-1">
                <UIcon name="i-heroicons-arrow-left" size="24" />
              </ULink>
              <h1>Login</h1>
            </div>
          </template>
          <div class="flex flex-col gap-4 items-center justify-center">
            <div>
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
            <div><h1>OR</h1></div>
            <UContainer>
              <UForm
                :validate="validate"
                :state="state"
                class="space-y-4"
                @submit="onSubmit"
              >
                <UFormGroup label="Email" name="email">
                  <UInput v-model="state.email" />
                </UFormGroup>
  
                <UFormGroup label="Password" name="password">
                  <UInput v-model="state.password" type="password" />
                </UFormGroup>
  
                <UButton
                  type="submit"
                  class="w-full flex items-center justify-center"
                >
                  Login
                </UButton>
              </UForm></UContainer
            >
          </div>
          <div v-if="err" class="text-red-500 text-center text-xs">{{ err }}</div>
          <div class="p-4">
            <p class="text-center text-xs text-gray-600 dark:text-gray-400">
              Don't have a SaleSpot account?
              <ULink
                to="/signup"
                active-class="text-primary dark:text-primary"
                inactive-class="text-primary dark:text-primary "
                >Sign Up</ULink
              >
            </p>
          </div>
        </UCard>
      </UModal>
    </div>
  </template>
  
  <script setup lang="ts">
  const client = useSupabaseClient();
  const user = useSupabaseUser();
  const isOpen = ref(true);
  const err = ref("");
  import type { FormError, FormSubmitEvent } from "#ui/types";
  
  const state = ref({
    email: undefined,
    password: undefined,
  });
  
  const validate = (state: any): FormError[] => {
    const errors = [];
    if (!state.email) errors.push({ path: "email", message: "Required" });
    if (!state.password) errors.push({ path: "password", message: "Required" });
    return errors;
  };
  async function signInWithEmail() {
    // for type fix and safety
    if (!state.value.email || !state.value.password) return;
    const { data, error } = await client.auth.signInWithPassword({
      email: state.value.email,
      password: state.value.password,
    });
    if (error) {
      err.value = error.message;
    }
  }
  
  async function onSubmit(event: FormSubmitEvent<any>) {
    signInWithEmail();
    navigateTo("/");
  }
  
  watchEffect(() => {
    if (user.value) {
      return navigateTo("/");
    }
  });
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
  </script>
  