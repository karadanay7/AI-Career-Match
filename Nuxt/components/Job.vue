<template>
    <UCard class="w-56 sm:w-72 h-full dark:bg-gray-800">
      <template #header class="bg-violet-300">
        <h2 class="text-base sm:text-lg font-semibold">{{ jobTitle }}</h2>
      </template>
      <div class="h-32 sm:h-44">
        <img :src="companyLogoUrl" alt="" class="w-full h-full object-cover rounded-md" />
      </div>
  
      <template #footer>
        <div class="text-xs sm:text-sm">
          <p>
            <span class="font-semibold text-primary-500 dark:text-primary-400">Company:</span>
            {{ companyName }}
          </p>
          <p>
            <span class="font-semibold">Employer:</span>
            {{ employerName }}
          </p>
          <p>
            <span class="font-semibold">Salary:</span>
            {{ minSalary }} - {{ maxSalary }} USD
          </p>
          <p>
            <span class="font-semibold">Work Style:</span>
            {{ workStyle }}
          </p>
          <p>
            <span class="font-semibold">Required Skills:</span>
            {{ requiredSkills.join(", ") }}
          </p>
          <p v-if="applicationDeadline">
            <span class="font-semibold">Application Deadline:</span>
            {{ applicationDeadline }}
          </p>
          <p>
            <span class="font-semibold">Posted Date:</span>
            {{ postedDate }}
          </p>
        </div>
      </template>
    </UCard>
  </template>
  
  <script setup>
  defineProps([
    "jobTitle",
    "companyLogoUrl",
    "companyName",
    "employerName",
    "minSalary",
    "maxSalary",
    "workStyle",
    "requiredSkills",
    "applicationDeadline",
    "postedDate",
  ]);
  </script>
  