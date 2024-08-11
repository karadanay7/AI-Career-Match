<template>
    <div class="min-h-screen  py-10">
      <UContainer class="flex flex-col items-center">
        <div class="relative w-full max-w-[700px]  rounded-lg shadow-md p-8">
          <!-- Avatar and Background -->
          <div class="relative flex justify-center">
            <div class="absolute -top-20 flex flex-col items-center">
              <img class="h-24 w-24 rounded-full border-4 border-white object-cover"
                src="/images/avatar-placeholder.png"
                alt="Avatar">
              <div class="text-center mt-4">
                <p class="text-2xl font-semibold">{{ user.name }}</p>
                <p class="">{{ user.title }}</p>
              </div>
            </div>
          </div>
  
          <!-- Profile Content -->
          <div class="mt-24">
            <!-- Contact Information -->
            <div class="flex justify-between items-center border-b pb-4 mb-6">
              <div class="">
                <p><i class="fas fa-envelope mr-2"></i>{{ user.email }}</p>
                <p><i class="fas fa-phone mr-2"></i>{{ user.phone }}</p>
                <p><i class="fas fa-map-marker-alt mr-2"></i>{{ user.location }}</p>
              </div>
              <div class="flex space-x-4 text-blue-600">
                <a :href="user.linkedin" target="_blank"><i class="fab fa-linkedin fa-lg"></i></a>
                <a :href="user.github" target="_blank"><i class="fab fa-github fa-lg"></i></a>
                <a :href="user.website" target="_blank"><i class="fas fa-globe fa-lg"></i></a>
                <a :href="user.twitter" target="_blank"><i class="fab fa-twitter fa-lg"></i></a>
                <a :href="user.instagram" target="_blank"><i class="fab fa-instagram fa-lg"></i></a>
              </div>
            </div>
  
            <!-- About Section -->
            <div class="mb-6">
              <h3 class="text-lg font-semibold mb-2">About</h3>
              <p>{{ user.experience }}</p>
            </div>
  
            <!-- Skills Section -->
            <div class="mb-6">
              <h3 class="text-lg font-semibold mb-2">Skills</h3>
              <ul class="flex flex-wrap space-x-2">
                <li v-for="skill in user.skills.split(', ')" :key="skill" class="bg-blue-100 text-blue-800 rounded-full px-3 py-1 text-sm font-medium">
                  {{ skill }}
                </li>
              </ul>
            </div>
  
            <!-- Experience Section -->
            <div class="mb-6">
              <h3 class="text-lg font-semibold mb-2">Experience</h3>
              <p>{{ user.experience }}</p>
            </div>
  
            <!-- Education Section -->
            <div class="mb-6">
              <h3 class="text-lg font-semibold mb-2">Education</h3>
              <p>{{ user.education }}</p>
            </div>
  
            <!-- Resume and Portfolio -->
            <div class="flex space-x-4">
              <a :href="user.resume" target="_blank" class="text-blue-600 hover:underline">View Resume</a>
              <a :href="user.portfolio" target="_blank" class="text-blue-600 hover:underline">View Portfolio</a>
            </div>
          </div>
        </div>
      </UContainer>
    </div>
  </template>
  
  <script setup lang="ts">
  import { reactive } from 'vue';
  
  // Example user information
  const user = reactive({
    name: 'John Doe',
    title: 'Web Developer',
    email: 'john.doe@example.com',
    phone: '+1 (123) 456-7890',
    location: 'San Francisco, CA',
    skills: 'JavaScript, Vue.js, Node.js, CSS',
    experience: '5 years in web development',
    education: 'Bachelor of Computer Science',
    resume: 'https://example.com/resume.pdf',
    portfolio: 'https://portfolio.example.com',
    linkedin: 'https://linkedin.com/in/johndoe',
    github: 'https://github.com/johndoe',
    website: 'https://johndoe.com',
    twitter: 'https://twitter.com/johndoe',
    instagram: 'https://instagram.com/johndoe'
  });
  </script>
  
  <style scoped>
  /* Add styles if needed */
  </style>
  