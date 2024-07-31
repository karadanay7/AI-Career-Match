<template>
    <div class="h-full w-full ">
      <div class="JobList container mx-auto flex flex-col gap-1 md:gap-5">
        <div v-for="(category, i) in jobCategories" :key="i">
          <UBadge size="xl" :ui="{ rounded: 'rounded-lg' }" class="ml-2">{{ category }}</UBadge>
  
          <ul class="flex items-stretch gap-4 overflow-x-auto max-w-full py-3">
            <li v-for="job in jobListings" :key="job.id" class="JobBox p-2 rounded-lg">
              <Job
                :jobTitle="job.title"
                :companyLogoUrl="job.company.logoUrl"
                :companyName="job.company.name"
                :employerName="job.employer.name"
                :minSalary="job.minSalary"
                :maxSalary="job.maxSalary"
                :workStyle="job.workStyle"
                :requiredSkills="job.requiredSkills"
                :applicationDeadline="job.applicationDeadline"
                :postedDate="job.postedDate"
              />
            </li>
          </ul>
        </div>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  const jobCategories = ["Engineering", "Design", "Marketing", "Sales", "HR"];
  const jobListings = [
    {
      id: 1,
      title: "Frontend Developer",
      company: {
        name: "TechCorp",
        logoUrl: "https://example.com/company-logo1.png",
      },
      employer: {
        name: "Jane Doe",
      },
      minSalary: 60000,
      maxSalary: 80000,
      workStyle: "Remote",
      requiredSkills: ["JavaScript", "Vue.js", "CSS"],
      applicationDeadline: "2024-08-15",
      postedDate: "2024-07-25",
    },
    {
      id: 2,
      title: "UI/UX Designer",
      company: {
        name: "DesignHub",
        logoUrl: "https://example.com/company-logo2.png",
      },
      employer: {
        name: "John Smith",
      },
      minSalary: 50000,
      maxSalary: 70000,
      workStyle: "On-site",
      requiredSkills: ["Figma", "Adobe XD", "Sketch"],
      applicationDeadline: "2024-08-20",
      postedDate: "2024-07-28",
    },
    // Add more job listings as needed
  ];
  </script>
  
  <style scoped>
  /* Add styles for the JobBox */
  </style>
  