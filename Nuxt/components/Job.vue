<template>
    <UCard class="w-56 sm:w-72 h-full dark:bg-gray-800">
        <template #header class="bg-violet-300 flex items-center space-x-4 p-4">

            <div class="flex items-center gap-4">
                <div> <img :src="company.logoUrl" alt="Company Logo" class="w-12 h-12 rounded-full object-cover" />
                </div>
                <div>
                    <h2 class="text-base font-semibold">{{ company.name }}</h2>
                </div>
            </div>
        </template>
        <div class="p-4 space-y-4">
            <h3 class="text-lg font-bold">{{ title }}</h3>
            <p class="text-sm">{{ description }}</p>
            <div class="flex flex-wrap gap-2">
                <span v-for="skill in requiredSkills" :key="skill"
                    class="bg-blue-200 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
                    {{ skill }}
                </span>
            </div>
            <p class="text-sm">
                <span class="font-semibold">Salary:</span>
                {{ minSalary ? `$${minSalary}` : '' }} - {{ maxSalary ? `$${maxSalary}` : 'N/A' }}
            </p>
            <p class="text-sm">
                <span class="font-semibold">Work Style:</span>
                {{ workStyle }}
            </p>
            <p class="text-sm">
                <span class="font-semibold">Experience:</span>
                {{ requiredExperienceTime ? `${requiredExperienceTime} years` : 'Not specified' }}
            </p>

            <p class="text-sm">
                <span class="font-semibold">Application Deadline:</span>
                {{ applicationDeadline ? new Date(applicationDeadline).toLocaleDateString() : 'Open until filled' }}
            </p>

            <p class="text-sm">
                <span class="font-semibold">Languages:</span>
                {{ requiredLanguages ? requiredLanguages.join(", ") : 'Not specified' }}
            </p>
            <div class="flex justify-between pt-4">
        <UButton @click="saveJob">Save</UButton>
        <UButton @click="goToApplyPage" >Apply</UButton>
      </div>


        </div>
    </UCard>
</template>

<script setup>
const props = defineProps([
    "id",
    "title",
    "description",
    "workStyle",
    "minSalary",
    "maxSalary",
    "requiredSkills",
    "requiredExperienceTime",
    "requiredEducationLevel",
    "responsibilities",
    "qualifications",
    "specificBenefits",
    "applicationDeadline",
    "postedDate",
    "requiredLanguages",
    "interviewProcess",
    "travelRequirement",
    "company"
]);

const router = useRouter();


const GoToApplyPage = () => {
    router.push(`/jobs/${props.id}`);
};
</script>