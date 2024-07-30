<template>
    <div class="flex flex-col items-center justify-center min-h-screen p-6">
        <UCard :ui="{
            ring: '',
            divide: 'divide-y divide-gray-100 dark:divide-gray-800',
        }">
            <template #header>
                <div class="flex items-center justify-center relative">
                    <NuxtLink to="/" class="absolute left-0 top-1">
                        <UIcon name="i-heroicons-arrow-left" size="32" class="md:mt-1" />
                    </NuxtLink>
                    <h1 class="text-lg ">Complete Company Profile</h1>
                </div>
            </template>
            <UForm :validate="validateWithVuelidate" :state="form">
                <div class="p-4 min-w-[300px]">
                 
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
                            <div class="flex items-center gap-4">
                                <div class="relative h-32 w-32 border-2 border-dashed flex justify-center items-center overflow-hidden mt-4">
                                    <div v-if="previewSrc" class="w-full h-full">
                                        <div class="relative w-full h-full flex justify-center items-center">
                                            <img :src="previewSrc" alt="Image Preview" class="object-cover w-full h-full" />
                                            <button @click="handleFileChange" class="absolute top-0 right-0 text-red-500 font-extrabold bg-white rounded-full h-5 w-5  ">
                                                <UIcon name="i-heroicons-x-mark-16-solid" />
                                            </button>
                                        </div>
                                    </div>
                                    <div v-else class="flex flex-col justify-center items-center w-full h-full p-2">
                                        <div>
                                            <Icon class="text-primary" name="flat-color-icons:add-image" size="50" />
                                        </div>
                                        <h2 class="text-center text-lg mb-2">
                                            Drop or
                                            <span class="text-blue-500 cursor-pointer"> browse </span>
                                        </h2>
                                        <input type="file" accept="image/*" @change="previewImage"
                                            class="absolute inset-0 w-full h-full opacity-0 cursor-pointer"
                                            ref="previewFileInput" required />
                                    </div>
                                </div>
                            </div>
                        </UFormGroup>

                        <div>
                            <UFormGroup label="Social Media Links">
                                <div class="flex items-center w-full mb-2 gap-2"
                                    v-for="(link, index) in form.socialMediaLinks" :key="index">
                                    <div class="grow">
                                        <UInput v-model="form.socialMediaLinks[index]" type="text"
                                            :id="'socialMediaLink' + index" name="socialMediaLinks" />
                                    </div>
                                    <div class="shrink-0">
                                        <UIcon @click="removeSocialMediaLink(index)" name="i-heroicons-x-mark"
                                            class="cursor-pointer" />
                                    </div>
                                </div>
                            </UFormGroup>
                            <UButton @click="addSocialMediaLink" type="button" size="sm" class="mt-2" color="blue">
                                <UIcon name="i-heroicons-plus" size="20" />
                                Add
                            </UButton>
                        </div>
                    </div>
                </div>
            </UForm>
            <div class="flex justify-center p-6">
                <UButton @click="submitForm" type="button" size="sm" color="green">Register</UButton>
            </div>
            <div v-if="err" class="text-red-500 text-center text-xs">{{ err }}</div>
        </UCard>
    </div>
</template>

<script setup lang="ts">
const err = ref('');
const previewUrl = ref<string | null>(null);

const form = reactive({
    companyName: "",
    companySector: "",
    companySize: "",
    companyWebsite: "",
    companyDescription: "",
    companyLogo: null,
    socialMediaLinks: [""], // Initialize with one empty link
});
const previewSrc = ref<string | ArrayBuffer | null>(null);
const previewImage = (evt: { target: { files: FileList } }) => {
    const file = evt.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = () => {
            previewSrc.value = reader.result;
        };
        reader.readAsDataURL(file);
    }
};
const handleFileChange = () => {
    previewSrc.value = null; // Reset previewSrc
};

const addSocialMediaLink = () => {
    form.socialMediaLinks.push("");
};

const removeSocialMediaLink = (index: number) => {
    form.socialMediaLinks.splice(index, 1);
};

const submitForm = () => {
    // Handle form submission logic
};
</script>
