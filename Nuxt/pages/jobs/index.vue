<template>
    <div class="h-full w-full font-index">
      <div class="JobList container mx-auto flex flex-col gap-1 md:gap-5">
        <div v-for="category in categoryList" :key="category">
          <UBadge size="xl" :ui="{ rounded: 'rounded-lg' }" class="ml-2">{{ category }}</UBadge>
  
          <ul class="flex items-stretch gap-4 overflow-x-auto max-w-full py-3">
            <li v-for="job in jobList" :key="job.id" class="JobBox p-2 rounded-lg">
              <Job
                :title="job.title"
                :description="job.description"
                :workStyle="job.workStyle"
                :minSalary="job.minSalary"
                :maxSalary="job.maxSalary"
                :requiredSkills="job.requiredSkills"
                :requiredExperienceTime="job.requiredExperienceTime"
                :requiredEducationLevel="job.requiredEducationLevel"
                :responsibilities="job.responsibilities"
                :qualifications="job.qualifications"
                :specificBenefits="job.specificBenefits"
                :applicationDeadline="job.applicationDeadline"
                :postedDate="job.postedDate"
                :requiredLanguages="job.requiredLanguages"
                :interviewProcess="job.interviewProcess"
                :travelRequirement="job.travelRequirement"
                :company="job.company"
              />
            </li>
          </ul>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  const categoryList = ["Engineering", "Marketing", "Sales", "Design", "Operations"];
  const jobList = [
    {
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
    },
    // Add more job data as needed
  ];
  </script>
  
  <style scoped>
  /* Add styles for the JobBox */
  </style>
  