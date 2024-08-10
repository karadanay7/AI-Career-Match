<template>
    <div class="min-h-screen p-8">
        <UContainer>
            <h1 class="text-2xl font-bold mb-6">Salary Ranges by Job Role</h1>
  
  <!-- Search Bar -->
  <div class="mb-6 space-y-4 md:flex md:space-y-0 md:space-x-4">
    <!-- Job Role Selection -->
    <UFormGroup class="w-[300px]" label="Job Role">
      <UInputMenu v-model="selectedRole" :options="uniqueRoles" />
    </UFormGroup>

    <!-- Location Selection -->
    <UFormGroup class="w-[300px]" label="Location">
      <UInputMenu v-model="selectedLocation" :options="uniqueLocations" />
    </UFormGroup>
  </div>

  <!-- Salary List -->
  <div class="space-y-4">
    <div
      v-for="role in filteredRoles"
      :key="role.id"
      class="p-4 border rounded-lg shadow-sm bg-slate-50 dark:bg-gray-800"
    >
      <h2 class="text-xl font-semibold">{{ role.title }}</h2>
      <p class="text-gray-600 dark:text-gray-400">{{ role.location }}</p>
      <div class="flex justify-between items-center mt-2">
        <span class="text-lg font-medium">Salary Range:</span>
        <span class="text-gray-700 dark:text-gray-300">
          ${{ role.salary.min }} - ${{ role.salary.max }} per year
        </span>
      </div>
    </div>
  </div>
        </UContainer>
     
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref, computed } from 'vue';
  
  // Sample data for job roles
  const jobRoles = [
    { id: 1, title: 'Software Engineer', location: 'San Francisco, CA', salary: { min: 100000, max: 150000 } },
    { id: 2, title: 'Product Manager', location: 'New York, NY', salary: { min: 90000, max: 130000 } },
    { id: 3, title: 'UX Designer', location: 'Remote', salary: { min: 75000, max: 105000 } },
    { id: 4, title: 'Data Scientist', location: 'Los Angeles, CA', salary: { min: 110000, max: 160000 } },
    { id: 5, title: 'DevOps Engineer', location: 'Austin, TX', salary: { min: 95000, max: 140000 } },
    { id: 6, title: 'Marketing Specialist', location: 'Chicago, IL', salary: { min: 60000, max: 90000 } },
  ];
  
  // Reactive variables for the selected filters
  const selectedRole = ref('Software Engineer');
  const selectedLocation = ref('San Francisco, CA');
  
  // Computed property to get unique job roles
  const uniqueRoles = computed(() => {
    return [...new Set(jobRoles.map(job => job.title))];
  });
  
  // Computed property to get unique locations
  const uniqueLocations = computed(() => {
    return [...new Set(jobRoles.map(job => job.location))];
  });
  
  // Computed property to filter job roles based on selected role and location
  const filteredRoles = computed(() => {
    return jobRoles.filter(job => {
      return (
        (selectedRole.value === '' || job.title === selectedRole.value) &&
        (selectedLocation.value === '' || job.location === selectedLocation.value)
      );
    });
  });
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  