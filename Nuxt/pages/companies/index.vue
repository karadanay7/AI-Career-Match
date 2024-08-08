<template>
    <NuxtLayout :name="companylayout">
    <div>
      <h1 class="text-2xl font-bold mb-4">Company Listings</h1>
      <div v-if="companies.length">
        <ul class="list-disc pl-5">
          <li v-for="company in companies" :key="company.id" class="mb-2">
            <NuxtLink :to="`/companies/${company.id}`" class="text-blue-500 hover:underline">
              {{ company.title }}
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
    layout: 'companydefault'
  });
  
  const companies = ref([]);
  
  onMounted(async () => {
    companies.value = await fetchCompanyList();
  });
  
  async function fetchCompanyList() {
    return [
      { id: 1, title: 'Software Engineer' },
      { id: 2, title: 'Product Manager' },
      { id: 3, title: 'UX Designer' },
      { id: 4, title: 'Data Scientist' }
      // Add more job data here
    ];
  }
  </script>
  
  