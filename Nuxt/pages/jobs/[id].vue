<template>
    <div>
      <h1>Job Details</h1>
      <p><strong>Title:</strong> {{ job.title }}</p>
      <p><strong>Description:</strong> {{ job.description }}</p>
      <!-- Add more job details here -->
    </div>
  </template>
  
  <script setup>

  
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
      id,
      title: 'Sample Job Title',
      description: 'Sample job description',
      // Add more job details here
    };
  }
  </script>
  