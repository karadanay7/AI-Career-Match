<template>
    <div class="w-[400px] p-4 border-r border-gray-200">
      <!-- Job Categories Section -->
      <section class="mb-6">
        <h2 class="text-xl font-semibold mb-4">Job Categories</h2>
        <ul class="space-y-4">
          <li v-for="job in jobList" :key="job.id">
            <NuxtLink :to="`/jobs/${job.id}`" class="block p-4 rounded bg-slate-100 dark:bg-gray-800 hover:dark:bg-gray-700 hover:bg-slate-300">
              <h3 class="font-semibold text-lg">{{ job.title }}</h3>
              <p class="text-gray-600 dark:text-gray-400">{{ job.company }}</p>
              <p class="text-sm text-gray-500 dark:text-gray-500">{{ job.location }}</p>
              <p class="text-sm text-gray-400 dark:text-gray-600 mt-2">{{ job.description }}</p>
            </NuxtLink>
          </li>
        </ul>
      </section>
    </div>
  </template>
  
  <script setup lang="ts">
  const jobList = [
    {
      id: 1,
      title: 'Software Engineer',
      company: 'Tech Corp',
      location: 'San Francisco, CA',
      description: 'Join our team to develop cutting-edge software solutions and work with the latest technologies.'
    },
    {
      id: 2,
      title: 'Product Manager',
      company: 'Innovate Inc.',
      location: 'New York, NY',
      description: 'Lead product development initiatives and work closely with engineering teams to deliver impactful products.'
    },
    {
      id: 3,
      title: 'UX Designer',
      company: 'Design Studio',
      location: 'Remote',
      description: 'Create engaging user experiences and interfaces for our diverse range of products.'
    },
    {
      id: 4,
      title: 'Data Scientist',
      company: 'Data Analytics Co.',
      location: 'Los Angeles, CA',
      description: 'Analyze complex data sets to drive business decisions and uncover valuable insights.'
    }
    // Add more job data here
  ];
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  