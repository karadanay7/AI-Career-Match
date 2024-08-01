<template>
    <div class="min-h-screen flex  ">
      <!-- Sidebar for Similar Jobs -->
      <JobSidebar />
  
      <!-- Main Content Area for Job Details -->
      <main class="flex-1 p-6">
        <UContainer>
          <div class=" p-6 rounded-lg shadow-lg border border-primary">
            <h1 class="text-3xl font-bold mb-4">{{ job.title }}</h1>
            <p class="mb-2"><strong>Company:</strong> {{ }}</p>
            <p class="mb-4"><strong>Description:</strong> {{ job.description }}</p>
  
            <!-- Add more job details here -->
            <div class="mb-4">
              <p><strong>Work Style:</strong> {{ job.workStyle }}</p>
              <p><strong>Salary:</strong> ${{ job.minSalary }} - ${{ job.maxSalary }}</p>
              <p><strong>Experience Required:</strong> {{ job.requiredExperienceTime }} years</p>
              <p><strong>Education Level:</strong> {{ job.requiredEducationLevel }}</p>
              <p><strong>Languages Required:</strong> {{ job.requiredLanguages }}</p>
              <p><strong>Application Deadline:</strong> {{ job.applicationDeadline }}</p>
            </div>
          </div>
        </UContainer>
      </main>
    </div>
  </template>
  
  <script setup lang="ts">
  
  
  const route = useRoute();
  const job = ref({});
  
  onMounted(async () => {
    const jobId = route.params.id;
    // Fetch the job details based on the jobId
    job.value = await fetchJobDetails(jobId);
  });
  
  async function fetchJobDetails(id) {
    // Replace this with your actual API call or data fetching logic
    return {
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
    };
  }
  </script>
  
  <style scoped>
  /* Add custom styles if needed */
  </style>
  