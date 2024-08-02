<template>
      <NuxtLayout :name="layout">
    <div v-if="job">
      <h1 class="text-2xl font-bold mb-4">{{ job.title }}</h1>
      <UContainer class="p-4  rounded-lg shadow-md">
        <p><strong>Company:</strong> {{ job.company.name }}</p>
        <p><strong>Description:</strong> {{ job.description }}</p>
        <p><strong>Work Style:</strong> {{ job.workStyle }}</p>
        <p><strong>Salary:</strong> ${{ job.minSalary }} - ${{ job.maxSalary }}</p>
        <p><strong>Experience Required:</strong> {{ job.requiredExperienceTime }} years</p>
        <p><strong>Education Level:</strong> {{ job.requiredEducationLevel }}</p>
        <p><strong>Languages Required:</strong> {{ job.requiredLanguages.join(', ') }}</p>
        <p><strong>Application Deadline:</strong> {{ new Date(job.applicationDeadline).toLocaleDateString() }}</p>
      </UContainer>
    </div>
    <div v-else>
      <p>Loading job details...</p>
    </div>
</NuxtLayout>
  </template>
  
  <script setup lang="ts">
 
  
  definePageMeta({
    layout: 'default'
  });
  
  const route = useRoute();
  const job = ref(null);
  
  onMounted(async () => {
    const jobId = route.params.id;
    job.value = await fetchJobDetails(jobId);
  });
  
  async function fetchJobDetails(id) {
    const jobs = [
      {
        id: 1,
        title: 'Software Engineer',
        description: 'Develop and maintain web applications.',
        workStyle: 'Remote',
        minSalary: 70000,
        maxSalary: 100000,
        requiredSkills: ['JavaScript', 'Vue.js', 'Node.js'],
        requiredExperienceTime: 3,
        requiredEducationLevel: "Bachelor's Degree",
        responsibilities: 'Write clean, maintainable code.',
        qualifications: '3+ years of experience in web development.',
        specificBenefits: ['Health insurance', 'Stock options'],
        applicationDeadline: '2024-12-31',
        postedDate: '2024-07-30',
        requiredLanguages: ['English'],
        interviewProcess: 'Phone interview, Technical interview, HR interview',
        travelRequirement: false,
        company: {
          name: 'TechCorp',
          logoUrl: '/images/companylogo.png'
        }
      },
      {
        id: 2,
        title: 'Product Manager',
        description: 'Lead product development and strategy.',
        workStyle: 'Hybrid',
        minSalary: 80000,
        maxSalary: 120000,
        requiredSkills: ['Product Management', 'Leadership', 'Agile'],
        requiredExperienceTime: 5,
        requiredEducationLevel: "Master's Degree",
        responsibilities: 'Manage product lifecycle from conception to launch.',
        qualifications: '5+ years in product management.',
        specificBenefits: ['Health insurance', '401(k)'],
        applicationDeadline: '2024-11-15',
        postedDate: '2024-06-01',
        requiredLanguages: ['English'],
        interviewProcess: 'Case study, Technical interview, HR interview',
        travelRequirement: true,
        company: {
          name: 'InnovateInc',
          logoUrl: '/images/companylogo2.png'
        }
      },
      // Add more job details here
    ];
  
    return jobs.find(job => job.id === parseInt(id));
  }
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  