<template>
    <UContainer
      class="w-full flex items-center justify-between border-b  border-primary dark:border-primary"
    >
      <div>
        <ULink to="/">
         <h1>AICareerMatch</h1>
        </ULink>
      </div>
      <div class="py-2">
        <UButton @click="toggleMenu()" class="md:hidden">
          <Icon
            :name="isMenuOpen ? 'pajamas:close' : 'pajamas:hamburger'"
            class="w-4 h-4 text-gray-300 dark:text-gray-900"
          />
        </UButton>
      </div>
  
      <div class="hidden md:flex">
        <UHorizontalNavigation :links="horizontalLinks" />
      </div>
  
      <div
        v-if="isMenuOpen"
        class="flex flex-col md:hidden top-11 absolute z-10 mx-auto left-0 right-0 border rounded-lg text-start bg-white dark:bg-gray-900 border-gray-300 dark:border-gray-600 justify-center py-2 items-center"
      >
        <div class="absolute top-0 w-full flex justify-end items-center">
          <NuxtLink
            v-if="user"
            @click="signOut()"
            size="xs"
            class="flex items-center w-full justify-end gap-1.5 text-sm text-primary p-2"
          >
            <Icon
              name="i-heroicons-arrow-right-start-on-rectangle-20-solid"
              class="text-primary"
            />
            Sign out
          </NuxtLink>
          <NuxtLink
            v-if="!user"
            @click="navigateAuth"
            size="xs"
            class="flex w-full items-center justify-end gap-1.5 text-sm text-primary p-2"
          >
            <Icon
              name="i-heroicons-arrow-right-start-on-rectangle-20-solid"
              class="text-primary"
            />
            Log in
          </NuxtLink>
        </div>
  
        <UVerticalNavigation :links="verticalLinks" />
      </div>
  
      <div class="flex items-center justify-center gap-2">
        <ULink
          v-if="!user"
          @click="navigateAuth"
          class="w-24 hidden md:flex items-center justify-center gap-1 text-sm hover:text-primary"
          size="xs"
          ><UIcon
            name="i-heroicons-arrow-right-end-on-rectangle-20-solid"
          />Login</ULink
        >
  
        <ULink
          class="hidden md:flex w-24 items-center justify-center gap-1 text-sm hover:text-primary"
          v-else
          @click="signOut()"
          size="xs"
        >
          <Icon name="i-heroicons-arrow-right-start-on-rectangle-20-solid" />
          Sign out
        </ULink>
        <UToggle
          v-model="isDark"
          on-icon="i-heroicons-moon"
          off-icon="i-heroicons-sun"
          size="lg"
        />
      </div>
    </UContainer>
   
  </template>
  <script setup lang="ts">

  const isMenuOpen = ref(false);
  const toggleMenu = () => (isMenuOpen.value = !isMenuOpen.value);
  
  const signOut = () => {
    supabase.auth.signOut();
    user.value = null;
  
    return navigateTo("/");
  };
  const navigateAuth = () => {
    return navigateTo("/auth");
  };
  
  const colorMode = useColorMode();
  const isDark = computed({
    get() {
      return colorMode.value === "dark";
    },
    set() {
      colorMode.preference = colorMode.value === "dark" ? "light" : "dark";
    },
  });
  const horizontalLinks = [
    [
     
     
      {
        label: "Jobs",
        icon: "i-heroicons-magnifying-glass-solid",
        to: "/jobs",
      },
      {
        label: "Companies",
        icon: "i-heroicons-building-storefront",
        to: "/companies",
      },
  
      {
        label: "Salaries",
        icon: "i-heroicons-banknotes",
        to: "/salaries",
      },
      {
        label: "Community",
        icon: "i-heroicons-user-group-solid",
        to: "/community",
      },
      {
        label: "For Employers",
        icon: "i-heroicons-bolt",
        to: "/employers",
      },
    ],
  ];
  const verticalLinks = [
    [
    {
        label: "Jobs",
        icon: "i-heroicons-magnifying-glass-solid",
        to: "/jobs",
      },
      {
        label: "Companies",
        icon: "i-heroicons-building-storefront",
        to: "/companies",
      },
  
      {
        label: "Salaries",
        icon: "i-heroicons-banknotes",
        to: "/salaries",
      },
      {
        label: "Community",
        icon: "i-heroicons-user-group-solid",
        to: "/community",
      },
      {
        label: "For Employers",
        icon: "i-heroicons-bolt",
        to: "/employers",
      },
    ],
  ];
  </script>
  