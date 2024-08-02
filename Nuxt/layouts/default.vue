<template>
    <div class="min-h-screen flex">
      <!-- Sidebar for Jobs -->
      <JobSidebar />
      
      <!-- Main Content Area -->
      <div class="flex-1 p-6">
        <slot />
      </div>
    </div>
  </template>