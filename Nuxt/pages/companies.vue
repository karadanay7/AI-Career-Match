<template>
    <div class="flex min-h-screen">
      <!-- Sidebar for Company List -->
      <div class="w-1/4 p-4 border-r border-gray-200">
        <h2 class="text-xl font-semibold mb-4">Companies</h2>
        <ul class="space-y-4">
          <li v-for="company in companies" :key="company.id">
            <button @click="selectCompany(company)" class="block p-4 rounded bg-slate-100 dark:bg-gray-800 hover:dark:bg-gray-700 hover:bg-slate-300 w-full text-left">
              <h3 class="font-semibold text-lg">{{ company.name }}</h3>
              <p class="text-gray-600 dark:text-gray-400">{{ company.location }}</p>
              <p class="text-sm text-gray-500 dark:text-gray-500">{{ company.industry }}</p>
              <p class="text-sm text-gray-400 dark:text-gray-600 mt-2">{{ company.description }}</p>
            </button>
          </li>
        </ul>
      </div>
      <!-- Company Details View -->
      <div class="w-3/4 p-4" v-if="selectedCompany">
        <h2 class="text-2xl font-semibold mb-2">{{ selectedCompany.name }}</h2>
        <p class="text-gray-600 dark:text-gray-400">{{ selectedCompany.location }}</p>
        <p class="text-sm text-gray-500 dark:text-gray-500">{{ selectedCompany.industry }}</p>
        <p class="text-gray-700 dark:text-gray-300 mt-4">{{ selectedCompany.description }}</p>
        <div class="mt-4">
          <p class="text-sm text-gray-500 dark:text-gray-500"><strong>Rating:</strong> {{ selectedCompany.rating }} / 5</p>
          <p class="text-sm text-gray-500 dark:text-gray-500"><strong>Number of Employees:</strong> {{ selectedCompany.employees }}</p>
          <p class="text-sm text-gray-500 dark:text-gray-500"><strong>About Company:</strong> {{ selectedCompany.about }}</p>
        </div>
      </div>
      <div v-else class="w-3/4 p-4">
        <p class="text-gray-600 dark:text-gray-400">Select a company to view details.</p>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue';
  
  const companies = [
    {
      id: 1,
      name: 'Tech Corp',
      location: 'San Francisco, CA',
      industry: 'Software Development',
      description: 'Leading the way in innovative software solutions for businesses around the world.',
      rating: 4.7,
      employees: 1500,
      about: 'Tech Corp specializes in providing comprehensive software solutions to enterprises worldwide. Our mission is to drive innovation through cutting-edge technology.'
    },
    {
      id: 2,
      name: 'Innovate Inc.',
      location: 'New York, NY',
      industry: 'Product Development',
      description: 'Specializing in creating cutting-edge products that shape the future of technology.',
      rating: 4.5,
      employees: 800,
      about: 'Innovate Inc. is dedicated to developing state-of-the-art products that redefine the tech landscape. We focus on innovation and excellence in every project.'
    },
    {
      id: 3,
      name: 'Design Studio',
      location: 'Remote',
      industry: 'Design and UX',
      description: 'Delivering exceptional user experiences through innovative design practices.',
      rating: 4.9,
      employees: 250,
      about: 'Design Studio is a leader in the field of user experience and design. Our team of experts crafts beautiful and intuitive interfaces that delight users.'
    },
    {
      id: 4,
      name: 'Data Analytics Co.',
      location: 'Los Angeles, CA',
      industry: 'Data Science',
      description: 'Harnessing the power of data to drive business decisions and innovation.',
      rating: 4.6,
      employees: 500,
      about: 'Data Analytics Co. transforms data into actionable insights. We help businesses make informed decisions through advanced data analysis and interpretation.'
    }
    // Add more company data here
  ];
  
  const selectedCompany = ref(null);
  
  const selectCompany = (company) => {
    selectedCompany.value = company;
  };
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  