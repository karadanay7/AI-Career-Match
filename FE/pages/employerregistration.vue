<template>
    <div class="flex flex-col items-center justify-center min-h-screen p-6">
        <UCard :ui="{
            ring: '',
            divide: 'divide-y divide-gray-100 dark:divide-gray-800',
        }">
            <template #header>
                <div class="flex items-center justify-center relative">
                    <ULink @click="pushHome" class="absolute left-0 top-1">
                        <UIcon name="i-heroicons-arrow-left" size="32" class="md:mt-1" />
                    </ULink>
                    <h1 class="text-lg md:text-2xl">Complete Company Profile</h1>
                </div>
            </template>
            <UForm :validate="validateWithVuelidate" :state="form">
                <div class="p-6 min-w-[300px]">
                    <h2 class="text-lg md:text-2xl text-center mb-4">Company Information</h2>
                    <div class="grid grid-cols-1 gap-4">
                        <UFormGroup label="Company Name *" name="companyName">
                            <UInput v-model="form.companyName" type="text" id="companyName" />
                        </UFormGroup>
                        <UFormGroup label="Company Sector *" name="companySector">
                            <UInput v-model="form.companySector" type="text" id="companySector" />
                        </UFormGroup>
                        <UFormGroup label="Company Size" name="companySize">
                            <UInput v-model="form.companySize" type="text" id="companySize" />
                        </UFormGroup>
                        <UFormGroup label="Company Website" name="companyWebsite">
                            <UInput v-model="form.companyWebsite" type="text" id="companyWebsite" />
                        </UFormGroup>
                        <UFormGroup label="Company Description" name="companyDescription">
                            <UInput v-model="form.companyDescription" type="text" id="companyDescription" />
                        </UFormGroup>
                        <UFormGroup label="Company Logo" name="companyLogo">
                            <UInput @change="handleFileChange" type="file" id="companyLogo" />
                        </UFormGroup>
                        <UFormGroup label="Social Media Links" name="socialMediaLinks">
                            <UInput v-model="form.socialMediaLinks" type="text" id="socialMediaLinks" />
                        </UFormGroup>
                    </div>
                </div>
            </UForm>
            <div class="flex justify-end p-6">
                <UButton @click="submitForm" type="button" size="sm" color="green">Submit</UButton>
            </div>
            <div v-if="err" class="text-red-500 text-center text-xs">{{ err }}</div>
        </UCard>
    </div>
</template>

<script setup lang="ts">


const err = ref('');

const form = reactive({
    companyName: "",
    companySector: "",
    companySize: "",
    companyWebsite: "",
    companyDescription: "",
    companyLogo: null,
    socialMediaLinks: "",
});

const handleFileChange = (event: Event) => {
    const target = event.target as HTMLInputElement;
    if (target.files && target.files[0]) {
        form.companyLogo = target.files[0];
    }
};

const submitForm = () => {
    // Add form submission logic here
    console.log('Form submitted', form);
};
</script>
