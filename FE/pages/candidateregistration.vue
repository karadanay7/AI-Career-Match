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
                    <h1 class="text-lg md:text-2xl">Complete Profile</h1>
                </div>
            </template>
            <UForm :validate="validateWithVuelidate" :state="form">
                <div v-if="step === 1" class="p-6 min-w-[300px]">
                    <h2 class="text-lg md:text-2xl text-center mb-4">Basic Information</h2>
                    <div class="grid grid-cols-1 gap-4">
                        <UFormGroup label="First Name *" name="firstName">
                            <UInput v-model="form.firstName" type="text" id="firstName" />
                        </UFormGroup>
                        <UFormGroup label="Last Name *" name="lastName">
                            <UInput v-model="form.lastName" type="text" id="lastName" />
                        </UFormGroup>
                        <UFormGroup label="Phone Number" name="phoneNumber">
                            <UInput v-model="form.phoneNumber" id="phoneNumber" />
                        </UFormGroup>
                    </div>
                </div>
                <div v-else-if="step === 2" class="p-6 min-w-[300px]">
                    <h2 class="text-xl mb-4 text-center">Professional Profile</h2>
                    <div class="grid grid-cols-1 gap-4">
                        <UFormGroup label="Skills" name="skills">
                            <UInput v-model="form.skills" id="skills" />
                        </UFormGroup>
                        <UFormGroup label="Education Level" name="educationLevel">
                            <UInput v-model="form.educationLevel" id="educationLevel" />
                        </UFormGroup>
                        <UFormGroup label="Experience" name="experience">
                            <UInput v-model="form.experience" type="number" id="experience" />
                        </UFormGroup>
                        <UFormGroup label="Resume" name="resume">
                            <UInput @change="handleFileChange" type="file" id="resume" />
                        </UFormGroup>
                        <UFormGroup label="LinkedIn Profile" name="linkedin">
                            <UInput v-model="form.linkedin" id="linkedin" />
                        </UFormGroup>
                        <UFormGroup label="GitHub Profile" name="github">
                            <UInput v-model="form.github" id="github" />
                        </UFormGroup>
                        <UFormGroup label="Other Links" name="otherLinks">
                            <UInput v-model="form.otherLinks" id="otherLinks" />
                        </UFormGroup>
                    </div>
                </div>
                <div v-else-if="step === 3" class="p-6 min-w-[300px]">
                    <h2 class="text-xl mb-4">Career Preferences</h2>
                    <div class="grid grid-cols-1 gap-4">
                        <UFormGroup label="Job Type" name="jobType">
                            <USelect
                                v-model="form.jobType"
                                :options="jobTypes"
                                option-attribute="name"
                                value-attribute="id"
                                placeholder="Select Job Type"
                            />
                        </UFormGroup>
                        <UFormGroup label="Desired Industry" name="desiredIndustry">
                            <UInput v-model="form.desiredIndustry" type="text" id="desiredIndustry" />
                        </UFormGroup>
                        <UFormGroup label="Desired Job Title" name="desiredJobTitle">
                            <UInput v-model="form.desiredJobTitle" type="text" id="desiredJobTitle" />
                        </UFormGroup>
                        <UFormGroup label="Desired Location" name="desiredLocation">
                            <UInput v-model="form.desiredLocation" type="text" id="desiredLocation" />
                        </UFormGroup>
                        <UFormGroup label="Desired Salary" name="desiredSalary">
                            <UInput v-model="form.desiredSalary" type="number" id="desiredSalary" />
                        </UFormGroup>
                    </div>
                </div>
            </UForm>
            <div class="flex justify-between p-6">
                <UButton v-if="step > 1" @click="prevStep" type="button" size="sm">Previous</UButton>
                <UButton v-if="step < 3" :class="{'ml-auto': step === 1}" @click="nextStep" type="button" size="sm">Next</UButton>
                <UButton v-if="step === 3" @click="submitForm" type="button" size="sm" color="green">Submit</UButton>
            </div>
            <div v-if="err" class="text-red-500 text-center text-xs">{{ err }}</div>
        </UCard>
    </div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';

const step = ref(1);
const err = ref('');

const form = reactive({
    firstName: "",
    lastName: "",
    phoneNumber: "",
    skills: "",
    experience: 0,
    educationLevel: "",
    resume: null,
    linkedin: "",
    github: "",
    otherLinks: "",
    jobType: "",
    desiredIndustry: "",
    desiredJobTitle: "",
    desiredLocation: "",
    desiredSalary: 0,
});

const jobTypes = [
    { id: 1, name: "Full-time" },
    { id: 2, name: "Part-time" },
    { id: 3, name: "Contract" },
    { id: 4, name: "Temporary" },
];

const nextStep = () => {
    if (step.value < 3) {
        step.value++;
    }
};

const prevStep = () => {
    if (step.value > 1) {
        step.value--;
    }
};

const handleFileChange = (event: Event) => {
    const target = event.target as HTMLInputElement;
    if (target.files && target.files[0]) {
        form.resume = target.files[0];
    }
};

const submitForm = () => {
    // Add form submission logic here
    console.log('Form submitted', form);
};
</script>
