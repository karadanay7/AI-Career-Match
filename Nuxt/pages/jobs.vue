<template>
    <div class="min-h-screen flex">
      <!-- Sidebar for Similar Jobs -->
      <JobSidebar :jobs="jobs" @selectJob="selectJob" />
  
      <!-- Main Content Area for Job Details -->
      <main class="flex-1 p-6">
        <UContainer>
          <JobDetail :job="selectedJob" />
        </UContainer>
      </main>
    </div>
  </template>
  
  <script setup lang="ts">

  
  const selectedJob = ref(null);
  const jobs = ref([]);
  
  const selectJob = (job) => {
    selectedJob.value = job;
  };
  
  onMounted(() => {
    jobs.value = getSampleJobs();
  });
  
  function getSampleJobs() {
    return [
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
          logoUrl: '/images/companylogo.png',
        },
      },
      {
        id: 2,
        title: 'Marketing Specialist',
        description: 'Plan and execute marketing campaigns.',
        workStyle: 'On-site',
        minSalary: 50000,
        maxSalary: 70000,
        requiredSkills: ['SEO', 'Content Marketing', 'Social Media'],
        requiredExperienceTime: 2,
        requiredEducationLevel: "Bachelor's Degree",
        responsibilities: 'Create and manage marketing campaigns.',
        qualifications: '2+ years of experience in marketing.',
        specificBenefits: ['Health insurance', '401(k)'],
        applicationDeadline: '2024-11-30',
        postedDate: '2024-06-15',
        requiredLanguages: ['English'],
        interviewProcess: 'Phone interview, On-site interview, HR interview',
        travelRequirement: false,
        company: {
          name: 'MarketMasters',
          logoUrl: '/images/marketmasters.png',
        },
      },
      // Add more job data as needed
    ];
  }
  </script>
  
  <style scoped>
  /* Add custom styles if needed */
  </style>
  