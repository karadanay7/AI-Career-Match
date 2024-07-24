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
                    <h1 class="text-lg md:text-2xl  "> Complete Profile</h1>
                </div>
            </template>
            <div v-if="step === 1" class="p-6 min-w-[300px]">
                <h2 class="text-lg md:text-2xl text-center mb-4">Basic Information</h2>
                <div class="grid grid-cols-1  gap-4">
                    <UFormGroup label="First Name *" name="firstName">
                        
                        <UInput v-model="form.firstName" type="text" id="firstName" />
                    </UFormGroup>
                    <UFormGroup label="Last Name *" name="lastName">
                        
                        <UInput v-model="form.lastName" type="text" id="lastName" />
                    </UFormGroup>
                    <UFormGroup label="Phone Number" name="phoneNumber">
                        
                        <UInput v-model="form.formNumber"  id="phoneNumber" />
                    </UFormGroup>
                </div>
            </div>
            <div v-else-if="step === 2" class="p-6 min-w-[300px]">
                <h2 class="text-xl mb-4 text-center">Professional Profile</h2>
                <div class="grid grid-cols-1  gap-4">
                    <UFormGroup label="Skills" name="skills">
                        
                        <UInput v-model="form.skills"  id="skills" />
                    </UFormGroup>
                    <UFormGroup label="Education Level" name="educationLevel">
                        
                        <UInput v-model="form.educationLevel"  id="educationLevel" />
                    </UFormGroup>
                    <UFormGroup label="Experience" name="experience">
                        
                        <UInput v-model="form.experience"  type="number" id="experience"  />
                    </UFormGroup>
                    <UFormGroup label="Resume" name="resume">
                        
                        <UInput @change="handleFileChange" v-model="form.resume"  type="file" id="resume"  />
                    </UFormGroup>
                    <UFormGroup label="Linkedin Profile" name="linkedin">
                        
                        <UInput v-model="form.linkedin"  id="linkedin" />
                    </UFormGroup>
                    <UFormGroup label="Github Profile" name="github">
                        
                        <UInput v-model="form.github"  id="github" />
                    </UFormGroup>
                    <UFormGroup label="Other Links" name="otherLinks">
                        
                        <UInput v-model="form.otherLinks"  id="otherLinks" />
                    </UFormGroup>
                  
                 
                </div>
            </div>
            <div v-else-if="step === 3" class="p-6 min-w-[300px]">
                <h2 class="text-xl mb-4">Career Preferences</h2>
                <div class="grid grid-cols-1  gap-4">
                    <div>
                        <label for="jobType" class="block text-sm font-medium">Job Type</label>
                        <select v-model="form.jobType" id="jobType" class="mt-1 block w-full">
                            <option value="" disabled>Select Job Type</option>
                            <option value="Full-time">Full-time</option>
                            <option value="Part-time">Part-time</option>
                            <option value="Contract">Contract</option>
                            <option value="Temporary">Temporary</option>
                        </select>
                    </div>
                    <div>
                        <label for="desiredIndustry" class="block text-sm font-medium">Desired Industry</label>
                        <input v-model="form.desiredIndustry" type="text" id="desiredIndustry" class="mt-1 block w-full"/>
                    </div>
                    <div>
                        <label for="desiredJobTitle" class="block text-sm font-medium">Desired Job Title</label>
                        <input v-model="form.desiredJobTitle" type="text" id="desiredJobTitle" class="mt-1 block w-full"/>
                    </div>
                    <div>
                        <label for="desiredLocation" class="block text-sm font-medium">Desired Location</label>
                        <input v-model="form.desiredLocation" type="text" id="desiredLocation" class="mt-1 block w-full"/>
                    </div>
                    <div>
                        <label for="desiredSalary" class="block text-sm font-medium">Desired Salary</label>
                        <input v-model="form.desiredSalary" type="number" id="desiredSalary" class="mt-1 block w-full"/>
                    </div>
                </div>
            </div>
            <div class="flex justify-between p-6">
                <UButton v-if="step > 1" @click="prevStep" type="button" size="sm">Previous</UButton>
                <UButton v-if="step < 3" :class="{'ml-auto': step === 1}" @click="nextStep" type="button" size="sm">Next</UButton>
                <UButton v-if="step === 3" @click="submitForm" type="button" size="sm">Submit</UButton>
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
    github:"",
    otherLinks:"",
    jobType: "",
    desiredIndustry: "",
    desiredJobTitle: "",
    desiredLocation: "",
    desiredSalary: 0,
});

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
