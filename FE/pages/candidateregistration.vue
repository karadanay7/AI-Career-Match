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
                <!-- Step 1: Basic Information -->
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

                <!-- Step 2: Professional Profile -->
                <div v-else-if="step === 2" class="p-6 min-w-[300px]">
                    <h2 class="text-xl mb-4 text-center">Professional Profile</h2>
                    <div class="grid grid-cols-1 gap-4">
                        <UFormGroup label="Title" name="title">
                            <UInput v-model="form.title" id="title" placeholder="e.g., Frontend Developer"/>
                        </UFormGroup>
                        <UFormGroup label="Skills" name="skills">
                            <UInput v-model="form.skills" id="skills" placeholder="Enter your skills" />
                        </UFormGroup>

                        <!-- Education Section -->
                        <div v-for="(education, index) in form.education" :key="index" class=" relative grid gap-4">
                            <h3 class="text-md mb-2">Education {{ index + 1 }}</h3>
                            <UButton class="absolute right-0 top-0" @click="removeEducation(index)" type="button" size="sm" color="red" icon="i-heroicons-x-mark"></UButton>
                            <UFormGroup label="Institution" :name="'institution-' + index">
                                <UInput v-model="education.institution" :id="'institution-' + index" placeholder="Enter institution" />
                            </UFormGroup>
                            <UFormGroup label="Degree" :name="'degree-' + index">
                                <UInput v-model="education.degree" :id="'degree-' + index" placeholder="Enter degree" />
                            </UFormGroup>
                            <UFormGroup label="Field of Study" :name="'fieldOfStudy-' + index">
                                <UInput v-model="education.fieldOfStudy" :id="'fieldOfStudy-' + index" placeholder="Enter field of study" />
                            </UFormGroup>
                            <UFormGroup label="Start Date" :name="'startDate-' + index">
                                <UInput v-model="education.startDate" :id="'startDate-' + index" type="date" />
                            </UFormGroup>
                            <UFormGroup label="End Date" :name="'endDate-' + index">
                                <UInput v-model="education.endDate" :id="'endDate-' + index" type="date" />
                            </UFormGroup>
                            <UFormGroup label="Description" :name="'description-' + index">
                                <UInput v-model="education.description" :id="'description-' + index" placeholder="Enter description" />
                            </UFormGroup>
                            <UFormGroup label="Grade/GPA" :name="'grade-' + index">
                                <UInput v-model="education.grade" :id="'grade-' + index" placeholder="Enter grade/GPA" />
                            </UFormGroup>
                        </div>

                        <div class="flex justify-start">
                            <UButton @click="addEducation"   type="button"  color="green" icon="i-heroicons-plus" class="w-36" >Education</UButton>
                        </div>

                        <!-- Experience Section -->
                        <div v-for="(experience, index) in form.experience" :key="index" class="border-b mb-2 relative">
                            <h3 class="text-md mb-2">Experience {{ index + 1 }}</h3>
                            <UButton class="absolute right-0 top-0" @click="removeExperience(index)" type="button" size="sm" color="red">Remove</UButton>
                            <UFormGroup label="Company" :name="'company-' + index">
                                <UInput v-model="experience.company" :id="'company-' + index" placeholder="Enter company" />
                            </UFormGroup>
                            <UFormGroup label="Title" :name="'title-' + index">
                                <UInput v-model="experience.title" :id="'title-' + index" placeholder="Enter title" />
                            </UFormGroup>
                            <UFormGroup label="Start Date" :name="'expStartDate-' + index">
                                <UInput v-model="experience.startDate" :id="'expStartDate-' + index" type="date" />
                            </UFormGroup>
                            <UFormGroup label="End Date" :name="'expEndDate-' + index">
                                <UInput v-model="experience.endDate" :id="'expEndDate-' + index" type="date" />
                            </UFormGroup>
                            <UFormGroup label="Description" :name="'expDescription-' + index">
                                <UInput v-model="experience.description" :id="'expDescription-' + index" placeholder="Enter description" />
                            </UFormGroup>
                        </div>

                        <div class="flex justify-start">
                            <UButton @click="addExperience" type="button"  class="w-36" color="green" size="sm" icon="i-heroicons-plus">Experience</UButton>
                        </div>

                        <UFormGroup label="Resume" name="resume">
                            <UInput @change="handleFileChange" type="file" id="resume" />
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

                <!-- Step 3: Career Preferences -->
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

            <!-- Navigation Buttons -->
            <div class="flex justify-between p-6">
                <UButton v-if="step > 1" @click="prevStep" type="button" size="sm" >Previous</UButton>
                <UButton v-if="step < 3" :class="{'ml-auto': step === 1}" @click="nextStep" type="button" size="sm">Next</UButton>
                <UButton v-if="step === 3" @click="submitForm" type="button" size="sm" color="green">Register</UButton>
            </div>
           
        </UCard>
    </div>
</template>

<script setup>


const form = ref({
    firstName: '',
    lastName: '',
    phoneNumber: '',
    title: '',
    skills: '',
    education: [],
    experience: [],
    resume: null,
    linkedin: '',
    github: '',
    otherLinks: '',
    jobType: '',
    desiredIndustry: '',
    desiredJobTitle: '',
    desiredLocation: '',
    desiredSalary: ''
    socialMediaLinks: [""],
})

const step = ref(1)
const jobTypes = ref([
    { id: 1, name: 'Full-Time' },
    { id: 2, name: 'Part-Time' },
    { id: 3, name: 'Contract' },
    { id: 4, name: 'Temporary' },
    { id: 5, name: 'Internship' }
])
const handleFileChange = () => {
    previewSrc.value = null; // Reset previewSrc
};

const addSocialMediaLink = () => {
    form.socialMediaLinks.push("");
};

const removeSocialMediaLink = (index: number) => {
    form.socialMediaLinks.splice(index, 1);
};





const nextStep = () => {
    if (step.value < 3) step.value++
}

const prevStep = () => {
    if (step.value > 1) step.value--
}

const addEducation = () => {
    form.value.education.push({
        institution: '',
        degree: '',
        fieldOfStudy: '',
        startDate: '',
        endDate: '',
        description: '',
        grade: ''
    })
}

const removeEducation = (index) => {
    form.value.education.splice(index, 1)
}

const addExperience = () => {
    form.value.experience.push({
        company: '',
        title: '',
        startDate: '',
        endDate: '',
        description: ''
    })
}

const removeExperience = (index) => {
    form.value.experience.splice(index, 1)
}

const handleFileChange = (event) => {
    form.value.resume = event.target.files[0]
}

const closeEducationSection = () => {
    form.value.education = []
}

const submitForm = () => {
    validateWithVuelidate().then(isValid => {
        if (isValid) {
            console.log('Form submitted:', form.value)
            // Submit form logic here
        }
    })
}
</script>

<style scoped>
/* Add any additional styles here */
</style>
