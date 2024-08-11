<template>
    <div class="min-h-screen">
        <CandidateProfile v-if="userRole === 'candidate'" />
        <EmployerProfile v-else-if="userRole === 'employer'" />
        <NotAuthorized v-else />
    </div>
</template>

<script setup lang="ts">


const userRole = ref('employer'); // Assuming the user role is 'candidate'. Update this accordingly.
</script>
