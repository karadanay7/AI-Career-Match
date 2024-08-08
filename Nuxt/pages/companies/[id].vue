<template>
  <NuxtLayout :name="companylayout">
    <UContainer>
      <div v-if="company" class="p-8  rounded-lg shadow-lg">
        <div class="flex flex-col lg:flex-row items-center lg:items-start lg:space-x-8">
          <img :src="company.logo" alt="Company Logo" class="w-24 h-24 mb-6 lg:mb-0 lg:w-48 lg:h-48 object-cover rounded-full shadow-md" />
          <div class="text-center lg:text-left">
            <h1 class="text-4xl font-bold mb-2">{{ company.name }}</h1>
            <p class="text-gray-500 text-lg mb-4">{{ company.location }}</p>
            <p class="text-xl text-gray-700 mb-4">{{ company.description }}</p>
            <p class="text-yellow-500 text-lg font-semibold">★ {{ company.rating }} / 5.0</p>
          </div>
        </div>
        <div class="mt-8 space-y-4">
          <p><strong>Industry:</strong> {{ company.industry }}</p>
          <p><strong>Employees:</strong> {{ company.employees }}</p>
          <p><strong>About:</strong> {{ company.about }}</p>
        </div>
      </div>
      <div v-else class="text-center p-8">
        <p>Loading company details...</p>
      </div>
    </UContainer>
  </NuxtLayout>
</template>


<script setup lang="ts">


definePageMeta({
  layout: 'companylayout'
});

const route = useRoute();
const company = ref(null);

onMounted(async () => {
  const companyId = route.params.id;
  company.value = await fetchCompanyDetails(companyId);
});

async function fetchCompanyDetails(id) {
 
    const companies = [
    {
      id: 1,
      name: 'Tech Corp',
      location: 'San Francisco, CA',
      industry: 'Software Development',
      description: 'Leading the way in innovative software solutions for businesses around the world.',
      rating: 4.7,
      employees: 1500,
      about: 'Tech Corp specializes in providing comprehensive software solutions to enterprises worldwide. Our mission is to drive innovation through cutting-edge technology.',
      logo: '/images/companylogo.png'
    },
    {
      id: 2,
      name: 'Innovate Inc.',
      location: 'New York, NY',
      industry: 'Product Development',
      description: 'Specializing in creating cutting-edge products that shape the future of technology.',
      rating: 4.5,
      employees: 800,
      about: 'Innovate Inc. is dedicated to developing state-of-the-art products that redefine the tech landscape. We focus on innovation and excellence in every project.',
        logo: '/images/companylogo.png'
    },
    {
      id: 3,
      name: 'Design Studio',
      location: 'Izmir, Turkey',
      industry: 'Design and UX',
      description: 'Delivering exceptional user experiences through innovative design practices.',
      rating: 4.9,
      employees: 250,
      about: 'Design Studio is a leader in the field of user experience and design. Our team of experts crafts beautiful and intuitive interfaces that delight users.',
        logo: '/images/companylogo.png'
    },
    {
      id: 4,
      name: 'Data Analytics Co.',
      location: 'Los Angeles, CA',
      industry: 'Data Science',
      description: 'Harnessing the power of data to drive business decisions and innovation.',
      rating: 4.6,
      employees: 500,
      about: 'Data Analytics Co. transforms data into actionable insights. We help businesses make informed decisions through advanced data analysis and interpretation.',
        logo: '/images/companylogo.png'
    }
    // Add more company data here
  ];
  

  return companies.find(company => company.id === parseInt(id));
}
</script>

<style scoped>
/* Add styles if needed */
</style>
