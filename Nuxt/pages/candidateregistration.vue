<template>
    <div class="flex flex-col items-center justify-center min-h-screen p-6">
      <UCard :ui="{ ring: '', divide: 'divide-y divide-gray-100 dark:divide-gray-800' }">
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
              <UFormGroup label="Your Location" name="address">
                <UInput v-model="form.address" id="address" />
              </UFormGroup>
            </div>
          </div>
  
          <!-- Step 2: Professional Profile -->
          <div v-else-if="step === 2" class="p-6 min-w-[300px]">
            <h2 class="text-xl mb-4 text-center">Professional Profile</h2>
            <div class="grid grid-cols-1 gap-4">
              <UFormGroup label="Title" name="title">
                <UInput v-model="form.title" id="title" placeholder="e.g., Frontend Developer" />
              </UFormGroup>  <UFormGroup label="Summary" name="summary">
                <UInput v-model="form.summary" id="summary" placeholder="Write about yourself" />
              </UFormGroup>
              <UFormGroup label="Skills" name="skills">
                <UInput v-model="form.skills" id="skills" placeholder="Enter your skills" />
              </UFormGroup>
              <UFormGroup label="Languages" name="languages">
                <UInput v-model="form.languages" id="languages" placeholder="Ex: Spanish, English" />
              </UFormGroup>
              <UFormGroup label="Work Experience" name="workExperience">
                <UInput v-model="form.workExperience" type="number" id="workExperience" placeholder="Ex: 2 years" />
              </UFormGroup>
  
              <!-- Education Section -->
              <div v-for="(education, index) in form.education" :key="index" class="relative grid gap-4">
                <h3 class="text-md mb-2">Education {{ index + 1 }}</h3>
                <UButton class="absolute right-0 top-0" @click="removeEducation(index)" type="button"  color="red" icon="i-heroicons-x-mark"></UButton>
                <UFormGroup label="Institution" :name="'institution-' + index">
                  <UInput v-model="education.institution" :id="'institution-' + index" placeholder="Ex: Boston University" />
                </UFormGroup>
                <UFormGroup label="Degree" :name="'degree-' + index">
                  <UInput v-model="education.degree" :id="'degree-' + index" placeholder="Ex: Bachelor's" />
                </UFormGroup>
                <UFormGroup label="Field of Study" :name="'fieldOfStudy-' + index">
                  <UInput v-model="education.fieldOfStudy" :id="'fieldOfStudy-' + index" placeholder="Ex: Business" />
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
                <UButton @click="addEducation" type="button" color="green" icon="i-heroicons-plus" class="w-36">Education</UButton>
              </div>
  
              <!-- Experience Section -->
              <div v-for="(experience, index) in form.experience" :key="index" class=" relative grid gap-4">
                <h3 class="text-md mb-2">Experience {{ index + 1 }}</h3>
                <UButton class="absolute right-0 top-0" @click="removeExperience(index)" type="button" icon="i-heroicons-x-mark" color="red"></UButton>
               
                <UFormGroup label="Company" :name="'company-' + index">
                  <UInput v-model="experience.company" :id="'company-' + index" placeholder="Ex: Tesla" />
                </UFormGroup>
                <UFormGroup label="Job Title" :name="'title-' + index">
                  <UInput v-model="experience.title" :id="'title-' + index" placeholder="Ex: Senior Software Engineer" />
                </UFormGroup>
                <UFormGroup label="Start Date" :name="'expStartDate-' + index">
                  <UInput v-model="experience.startDate" :id="'expStartDate-' + index" type="date" />
                </UFormGroup>
                <UFormGroup label="End Date" :name="'expEndDate-' + index">
                  <UInput v-model="experience.endDate" :id="'expEndDate-' + index" type="date" />
                </UFormGroup>
                <UFormGroup label="Responsibilities" :name="'expDescription-' + index">
                  <UInput v-model="experience.responsibilities" :id="'expDescription-' + index" placeholder="Enter description" />
                </UFormGroup>
              </div>
  
              <div class="flex justify-start">
                <UButton @click="addExperience" type="button" class="w-36" color="green"  icon="i-heroicons-plus">Experience</UButton>
              </div>
  
              <UFormGroup label="Resume" name="resume">
                <UInput v-model="form.resume" type="file"  ref="previewFileInput" />
              </UFormGroup>
  
              <div>
                <UFormGroup label="Social Media Links">
                  <div class="flex items-center w-full mb-2 gap-2" v-for="(link, index) in form.socialMediaLinks" :key="index">
                    <div class="grow">
                      <UInput v-model="form.socialMediaLinks[index]" type="text" :id="'socialMediaLink' + index" name="socialMediaLinks" />
                    </div>
                    <div class="shrink-0">
                      <UIcon @click="removeSocialMediaLink(index)" name="i-heroicons-x-mark" class="cursor-pointer" />
                    </div>
                  </div>
                </UFormGroup>
                <UButton @click="addSocialMediaLink" type="button" color="green" class="mt-2" icon="i-heroicons-plus">Add</UButton>
              </div>
            </div>
          </div>
  
          <!-- Step 3: Career Preferences -->
          <div v-else-if="step === 3" class="p-6 min-w-[300px]">
            <h2 class="text-xl mb-4">Career Preferences</h2>
            <div class="grid grid-cols-1 gap-4">
              <UFormGroup label="Preferred Job Type" name="preferredJobType">
                
                    <USelect v-model="form.preferredJobType" :options="jobTypes" />
               
              </UFormGroup>
              <UFormGroup label="Preferred Job Location" name="preferredJobLocation">
                <USelect v-model="form.preferredJobLocation" id="preferredJobLocation">
                  <option value="">Select Job Location</option>
                  <option value="remote">Remote</option>
                  <option value="onsite">Onsite</option>
                  <option value="hybrid">Hybrid</option>
                </USelect>
              </UFormGroup>
              <UFormGroup label="Expected Salary Range" name="expectedSalaryRange">
                <div class="grid grid-cols-2 gap-4">
                  <UInput v-model="form.salaryMin" type="number" id="salaryMin" placeholder="Min" />
                  <UInput v-model="form.salaryMax" type="number" id="salaryMax" placeholder="Max" />
                </div>
              </UFormGroup>
              <UFormGroup label="Career Goals" name="careerGoals">
                <UTextarea v-model="form.careerGoals" id="careerGoals" placeholder="Enter your career goals" />
              </UFormGroup>
            </div>
          </div>
  
          <!-- Navigation Buttons -->
          <div class="flex justify-between p-6">
          <UButton v-if="step > 1" @click="prevStep" type="button"  icon="i-heroicons-arrow-left" >Previous</UButton>
          <UButton v-else type="button" color="transparent" disabled></UButton>
          <UButton v-if="step < 3" @click="nextStep" type="button" color="primary"  >Next</UButton>
          <UButton v-else @click="submitForm" type="button"  icon="i-heroicons-check" color="green">Register</UButton>
        </div>
        </UForm>
      </UCard>
    </div>
  </template>
  
  <script setup>
 
  
  const step = ref(1)
  const jobTypes = ['Full-time', 'Part-time', 'Freelance', 'Contract', 'Hybrid', 'Remote']
  const form = ref({
    firstName: '',
    lastName: '',
    phoneNumber: '',
    title: '',
    summary: '',
    skills: '',
    workExperience: 0,
    address: '',
    languages: '',
    education: [
      {
        institution: '',
        degree: '',
        fieldOfStudy: '',
        startDate: '',
        endDate: '',
        description: '',
        grade: ''
      }
    ],
    experience: [
      {
        company: '',
        title: '',
        startDate: '',
        endDate: '',
        responsibilities: ''
      }
    ],
    resume: '',
    socialMediaLinks: [''],
    preferredJobType: '',
    preferredJobLocation: '',
    salaryMin: '',
    salaryMax: '',
    careerGoals: ''
  })
  
  
  
  
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
  
  const addSocialMediaLink = () => {
    form.value.socialMediaLinks.push('')
  }
  
  const removeSocialMediaLink = (index) => {
    form.value.socialMediaLinks.splice(index, 1)
  }
  
  const nextStep = () => {
    if (step.value < 3) step.value++
  }
  
  const prevStep = () => {
    if (step.value > 1) step.value--
  }
  
  const submitForm = () => {
    // Add form submission logic here
    console.log('Form submitted:', form.value)
  }
  
 
  
  
  </script>
  
  <style scoped>
  /* Add your styles here */
  </style>
  