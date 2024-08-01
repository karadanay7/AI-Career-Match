<template>
    <aside class="w-1/4 bg-slate-100 dark:bg-gray-900 p-4 shadow-lg">
      <h2 class="text-xl font-semibold mb-4">Similar Jobs</h2>
      <ul>
        <li
          v-for="similarJob in similarJobs"
          :key="similarJob.id"
          class="mb-4 p-2 border rounded cursor-pointer "
          @click="navigateToJob(similarJob.id)"
        >
          <h3 class="font-semibold">{{ similarJob.title }}</h3>
          <p class="text-sm text-gray-400">{{ similarJob.company.name }}</p>
        </li>
      </ul>
    </aside>
  </template>
  
  <script setup lang="ts">


  const similarJobs = ref([
    {
      id: 2,
      title: 'Frontend Developer',
      company: { name: 'Web Solutions' }
    },
    {
      id: 3,
      title: 'Backend Developer',
      company: { name: 'DataCorp' }
    }
    // Add more similar jobs here
  ]);
  
  const router = useRouter();
  
  function navigateToJob(id) {
    router.push(`/jobs/${id}`);
  }
  </script>
  
  <style scoped>
  /* Add custom styles if needed */
  </style>
  