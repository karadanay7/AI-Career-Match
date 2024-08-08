<template>
    <div class="min-h-screen  flex-col items-center justify-center">

        <div class="flex items-center justify-center py-5">

            <UInput     icon="i-heroicons-magnifying-glass-20-solid"
    size="md"
    color="white"
    :trailing="false"
    placeholder="Search Company..." class="w-1/2" />

        </div>
        <div class="flex">
            <div>
                <CompanySidebar />
            </div>
            <div class="flex-1 p-6">
                <slot />
            </div>
        </div>



    </div>

</template>