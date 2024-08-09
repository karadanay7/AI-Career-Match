<template>
    <div class="min-h-screen p-8">
      <h1 class="text-2xl font-bold mb-6">Salary Ranges by Job Role</h1>
  
      <!-- Search Bar -->
      <div class="mb-6 space-y-4 md:flex md:space-y-0 md:space-x-4">
        <div class="md:w-1/2">
          <label for="role" class="block text-sm font-medium text-gray-700 dark:text-gray-300">
            Job Role
          </label>
          <select
            id="role"
            v-model="selectedRole"
            class="mt-1 block w-full rounded-md border-gray-300 shadow-sm dark:bg-gray-700 dark:text-gray-300 focus:border-indigo-500 focus:ring-indigo-500"
          >
            <option value="">All Roles</option>
            <option v-for="role in uniqueRoles" :key="role">{{ role }}</option>
          </select>
        </div>
  
        <div class="md:w-1/2">
          <label for="location" class="block text-sm font-medium text-gray-700 dark:text-gray-300">
            Location
          </label>
          <select
            id="location"
            v-model="selectedLocation"
            class="mt-1 block w-full rounded-md border-gray-300 shadow-sm dark:bg-gray-700 dark:text-gray-300 focus:border-indigo-500 focus:ring-indigo-500"
          >
            <option value="">All Locations</option>
            <option v-for="location in uniqueLocations" :key="location">{{ location }}</option>
          </select>
        </div>
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
  const selectedRole = ref('');
  const selectedLocation = ref('');
  
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
  