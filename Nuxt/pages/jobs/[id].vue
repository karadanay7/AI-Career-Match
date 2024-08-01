<template>
    <div class=" min-h-screen">
        <UContainer>
            <h1>Job Details</h1>
      <p><strong>Title:</strong> {{ job.title }}</p>
      <p><strong>Description:</strong> {{ job.description }}</p>
        </UContainer>
      
      <!-- Add more job details here -->
    </div>
  </template>
  
  <script setup lang="ts">

  
  const route = useRoute();
  const job = ref({});
  
  onMounted(async () => {
    const jobId = route.params.id;
    // Fetch the job details based on the jobId
    // This is a placeholder, replace with your actual data fetching logic
    job.value = await fetchJobDetails(jobId);
  });
  
  async function fetchJobDetails(id) {
    // Replace this with your actual API call or data fetching logic
    return {
        id: 1,
      title: "Software Engineer",
      description: "Develop and maintain web applications.",
      workStyle: "Remote",
      minSalary: 70000,
      maxSalary: 100000,
      requiredSkills: ["JavaScript", "Vue.js", "Node.js"],
      requiredExperienceTime: 3,
      requiredEducationLevel: "Bachelor's Degree",
      responsibilities: "Write clean, maintainable code.",
      qualifications: "3+ years of experience in web development.",
      specificBenefits: ["Health insurance", "Stock options"],
      applicationDeadline: "2024-12-31",
      postedDate: "2024-07-30",
      requiredLanguages: ["English"],
      interviewProcess: "Phone interview, Technical interview, HR interview",
      travelRequirement: false,
      company: {
        name: "TechCorp",
        logoUrl: "/images/companylogo.png"
      }
      // Add more job details here
    };
  }
  </script>
  