<template>
  <div
    class="w-full flex items-center justify-between border-b border-primary dark:border-primary mx-auto px-4 sm:px-6 lg:px-8 max-w-7xl bg-slate-100 dark:bg-gray-900"
  >
    <div>
      <ULink to="/">
        <h1>AICareerMatch</h1>
      </ULink>
    </div>
    <div class="flex items-center gap-2 py-2 lg:hidden">
      <UToggle
        v-model="isDark"
        on-icon="i-heroicons-moon"
        off-icon="i-heroicons-sun"
        size="lg"
      />
      <UButton @click="toggleMenu()">
        <Icon
          :name="isMenuOpen ? 'pajamas:close' : 'pajamas:hamburger'"
          class="w-4 h-4 text-gray-300 dark:text-gray-900"
        />
      </UButton>
    </div>

    <div class="hidden lg:flex">
      <UHorizontalNavigation :links="horizontalLinks" />
    </div>

    <div
      v-if="isMenuOpen"
      class="flex flex-col lg:hidden top-11 absolute z-20 mx-auto left-0 right-0 border rounded-lg text-start border-gray-300 dark:border-gray-600 justify-center py-2 items-center bg-slate-100 dark:bg-gray-900"
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

    <div class="hidden lg:flex items-center justify-center gap-2">
      <UButton
        v-if="!user"
        @click="navigateAuth"
        class="hidden lg:flex"
        size="sm"
        icon="i-heroicons-arrow-right-end-on-rectangle-20-solid"
      >
        Login
      </UButton>

      <UButton
        class="hidden lg:flex w-24"
        v-else
        @click="signOut()"
        size="sm"
        icon="i-heroicons-arrow-right-end-on-rectangle-20-solid"
      >
        Logout
      </UButton>
      <UToggle
        v-model="isDark"
        on-icon="i-heroicons-moon"
        off-icon="i-heroicons-sun"
        size="lg"
      />
    </div>
  </div>
</template>
  <script setup lang="ts">
  const supabase = useSupabaseClient();
const user = useSupabaseUser();
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
        to: "/foremployers",
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
        to: "/foremployers",
      },
    ],
  ];
  </script>
  