<template>
     <div v-if="job" class="p-6 rounded-lg shadow-lg border border-primary">
    <h1 class="text-3xl font-bold mb-4">{{ job.title }}</h1>
    <p class="mb-2" v-if="job.company && job.company.name"><strong>Company:</strong> {{ job.company.name }}</p>
    <p class="mb-4"><strong>Description:</strong> {{ job.description }}</p>

    <!-- Add more job details here -->
    <div class="mb-4">
      <p><strong>Work Style:</strong> {{ job.workStyle }}</p>
      <p><strong>Salary:</strong> ${{ job.minSalary }} - ${{ job.maxSalary }}</p>
      <p><strong>Experience Required:</strong> {{ job.requiredExperienceTime }} years</p>
      <p><strong>Education Level:</strong> {{ job.requiredEducationLevel }}</p>
      <p><strong>Languages Required:</strong> {{ job.requiredLanguages.join(', ') }}</p>
      <p><strong>Application Deadline:</strong> {{ new Date(job.applicationDeadline).toLocaleDateString() }}</p>
    </div>
  </div>
  <div v-else>
    <p>Select a job to see details</p>
  </div>

  </template>
  
  <script setup lang="ts">

  
  const props = defineProps({
    job: {
      type: Object,
      default: null,
    },
  });
  </script>
  
  <style scoped>
  /* Add custom styles if needed */
  </style>
  