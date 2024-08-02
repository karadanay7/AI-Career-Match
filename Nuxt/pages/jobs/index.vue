<template>
    <NuxtLayout :name="layout">
    <div>
      <h1 class="text-2xl font-bold mb-4">Job Listings</h1>
      <div v-if="jobs.length">
        <ul class="list-disc pl-5">
          <li v-for="job in jobs" :key="job.id" class="mb-2">
            <NuxtLink :to="`/jobs/${job.id}`" class="text-blue-500 hover:underline">
              {{ job.title }}
            </NuxtLink>
          </li>
        </ul>
      </div>
      <div v-else>
        <p>No jobs available.</p>
      </div>
    </div>
</NuxtLayout>
  </template>
  
  <script setup lang="ts">

  
  definePageMeta({
    layout: 'default'
  });
  
  const jobs = ref([]);
  
  onMounted(async () => {
    jobs.value = await fetchJobList();
  });
  
  async function fetchJobList() {
    return [
      { id: 1, title: 'Software Engineer' },
      { id: 2, title: 'Product Manager' },
      { id: 3, title: 'UX Designer' },
      { id: 4, title: 'Data Scientist' }
      // Add more job data here
    ];
  }
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  