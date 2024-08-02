<template>
    <div class="w-1/4 p-4 border-r border-gray-200">
      <ul class="space-y-4">
        <li
          v-for="job in jobs"
          :key="job.id"
          class="cursor-pointer p-4 border rounded-lg bg-slate-100 dark:bg-gray-800 hover:dark:bg-gray-700 hover:bg-slate-300" 
          @click="selectJob(job)"
        >
          <h2 class="font-bold">{{ job.title }}</h2>
          <p>{{ job.company.name }}</p>
          <p>{{ job.workStyle }}</p>
          <p>{{ job.requiredExperienceTime }} years experience</p>
          <p>{{ job.requiredLanguages.join(', ') }}</p>
        </li>
      </ul>
    </div>
  </template>
  
  <script setup lang="ts">
 
  
  const props = defineProps({
    jobs: {
      type: Array,
      required: true,
    },
  });
  
  const emits = defineEmits(['selectJob']);
  
  const selectJob = (job) => {
    emits('selectJob', job);
  };
  </script>
  
  <style scoped>
  /* Add custom styles if needed */
  </style>
  