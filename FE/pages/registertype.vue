<template>
    <div class="flex flex-col items-center justify-center min-h-screen">
        
            <UCard :ui="{
                ring: '',
                divide: 'divide-y divide-gray-100 dark:divide-gray-800',
            }">
                <template #header>
                    <div class="flex items-center justify-center relative">
                        <ULink @click="pushHome" class="absolute left-0 top-1">
                            <UIcon name="i-heroicons-arrow-left" size="24" />
                        </ULink>
                        <h1 class="text-2xl">REGISTER AS</h1>
                    </div>
                </template>
                <div class="flex flex-col md:flex-row items-center justify-center md:space-x-8 gap-2 min-h-[300px] p-10">
                    <div class="flex flex-col items-center justify-center gap-3    p-2">
                        <div>
                            <img src="/images/candidate.png" alt="Candidate" class=" w-32 h-32  md:h-44 md:w-44 object-contain">
                        </div>
                        <div>
                            <UButton @click="loginAsCandidate('google')" type="button" size="sm"
                                class="flex items-center w-44 justify-center">
                                I'm a Candidate
                            </UButton>
                        </div>
                    </div>
                    <div class="flex items-center justify-center my-4 md:my-0 text-3xl text-center">
                       OR
                    </div>
                    <div class="flex flex-col items-center justify-center gap-3  p-2">
                        <div>
                            <img src="/images/employer.png" alt="Employer" class=" w-32 h-32 md:h-44 md:w-44 object-contain">
                        </div>
                        <div>
                            <UButton @click="loginAsCandidate('google')" type="button" size="sm"
                                class="flex items-center w-44 justify-center">
                                I'm an Employer
                            </UButton>
                        </div>
                    </div>
                </div>
                <div v-if="err" class="text-red-500 text-center text-xs">{{ err }}</div>
            </UCard>
       
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

const loginAsCandidate = async (_prov: any) => {
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
