<template>
    <div v-if="company" class="p-4">
      <h2 class="text-2xl font-semibold mb-2">{{ company.name }}</h2>
      <p class="text-gray-600 dark:text-gray-400">{{ company.location }}</p>
      <p class="text-sm text-gray-500 dark:text-gray-500">{{ company.industry }}</p>
      <p class="text-gray-700 dark:text-gray-300 mt-4">{{ company.description }}</p>
    </div>
  </template>
  
  <script setup lang="ts">

  
  const route = useRoute();
  const company = ref(null);
  const companies = [
    {
      id: 1,
      name: 'Tech Corp',
      location: 'San Francisco, CA',
      industry: 'Software Development',
      description: 'Leading the way in innovative software solutions for businesses around the world.'
    },
    {
      id: 2,
      name: 'Innovate Inc.',
      location: 'New York, NY',
      industry: 'Product Development',
      description: 'Specializing in creating cutting-edge products that shape the future of technology.'
    },
    {
      id: 3,
      name: 'Design Studio',
      location: 'Remote',
      industry: 'Design and UX',
      description: 'Delivering exceptional user experiences through innovative design practices.'
    },
    {
      id: 4,
      name: 'Data Analytics Co.',
      location: 'Los Angeles, CA',
      industry: 'Data Science',
      description: 'Harnessing the power of data to drive business decisions and innovation.'
    }
    // Add more company data here
  ];
  
  onMounted(() => {
    const companyId = Number(route.params.id);
    company.value = companies.find(comp => comp.id === companyId);
  });
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  