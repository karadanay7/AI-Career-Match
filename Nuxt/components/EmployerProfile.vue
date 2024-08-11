<template>
    <div class="min-h-screen py-10">
      <UContainer class="flex flex-col items-center">
        <div class="relative w-full max-w-[700px] rounded-lg shadow-md p-8">
          <!-- Company Logo and Background -->
          <div class="relative flex justify-center">
            <div class="absolute -top-20 flex flex-col items-center">
              <img class="h-24 w-24 rounded-full border-4 border-white object-cover"
                src="/images/companylogo.png" 
                alt="Company Logo">
              <div class="text-center mt-4">
                <p class="text-2xl font-semibold">{{ company.name }}</p>
                <p class="text-gray-500">{{ company.industry }}</p>
              </div>
            </div>
          </div>
  
          <!-- Company Content -->
          <div class="mt-24">
            <!-- Location Information -->
            <div class="flex justify-between items-center border-b pb-4 mb-6">
              <div>
                <p><i class="fas fa-map-marker-alt mr-2"></i>{{ company.location }}</p>
              </div>
            </div>
  
            <!-- Description Section -->
            <div class="mb-6">
              <h3 class="text-lg font-semibold mb-2">About</h3>
              <p>{{ company.description }}</p>
            </div>
          </div>
        </div>
      </UContainer>
    </div>
  </template>
  
  <script setup lang="ts">
  import { reactive } from 'vue';
  
  const company = reactive({
    name: 'Tech Innovators Inc.',
    industry: 'Software Development & AI Solutions',
    location: 'Silicon Valley, CA',
    description: `Tech Innovators Inc. is a leading company in the software development and AI industry. 
                  We specialize in creating cutting-edge solutions that drive digital transformation 
                  for businesses around the world. Our team of experts is dedicated to pushing the 
                  boundaries of technology, delivering innovative products that are both scalable and 
                  sustainable. From AI-driven analytics to custom software applications, Tech Innovators 
                  Inc. empowers companies to unlock their full potential in the digital age.`,
  });
  </script>
  
  <style scoped>
  /* Add any additional custom styles if needed */
  </style>
  