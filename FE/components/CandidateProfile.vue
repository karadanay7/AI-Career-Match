<template>
    <div class="">
        <UContainer class="flex flex-col items-center pt-10 ">
            <div class="relative w-full max-w-[700px]">
                <!-- Avatar background -->
                
                <!-- Avatar image and name with title -->
                <div class="flex items-center space-x-4">
                    <div>
                        <img class="h-24 w-24 rounded-full border-4 border-white object-contain"
                             src="/images/avatar-placeholder.png"
                             alt="Avatar">
                    </div>
                    <div>
                        <p class="text-xl font-semibold ">{{ user.name }}</p>
                        <p class="text-gray-300">{{ user.title }}</p> <!-- Replace with actual title -->
                    </div>
                </div>
            </div>
            <div class="w-full mt-16">
                <UForm class="max-w-[700px] mx-auto p-4  rounded-lg shadow-md">
                    <UField>
                        <ULabel>Name</ULabel>
                        <UInput v-model="user.name" />
                    </UField>
                    <UField>
                        <ULabel>Email</ULabel>
                        <UInput v-model="user.email" />
                    </UField>
                    <UField>
                        <ULabel>Phone</ULabel>
                        <UInput v-model="user.phone" />
                    </UField>
                    <UField>
                        <ULabel>Location</ULabel>
                        <UInput v-model="user.location" />
                    </UField>
                    <UField>
                        <ULabel>Skills</ULabel>
                        <UInput v-model="user.skills" />
                    </UField>
                    <UField>
                        <ULabel>Experience</ULabel>
                        <UInput v-model="user.experience" />
                    </UField>
                    <UField>
                        <ULabel>Education</ULabel>
                        <UInput v-model="user.education" />
                    </UField>
                    <UField>
                        <ULabel>Resume</ULabel>
                        <UInput v-model="user.resume" />
                    </UField>
                    <UField>
                        <ULabel>Portfolio</ULabel>
                        <UInput v-model="user.portfolio" />
                    </UField>
                    <UField>
                        <ULabel>LinkedIn</ULabel>
                        <UInput v-model="user.linkedin" />
                    </UField>
                    <UField>
                        <ULabel>GitHub</ULabel>
                        <UInput v-model="user.github" />
                    </UField>
                    <UField>
                        <ULabel>Website</ULabel>
                        <UInput v-model="user.website" />
                    </UField>
                    <UField>
                        <ULabel>Twitter</ULabel>
                        <UInput v-model="user.twitter" />
                    </UField>
                    <UField>
                        <ULabel>Instagram</ULabel>
                        <UInput v-model="user.instagram" />
                    </UField>
                </UForm>
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
