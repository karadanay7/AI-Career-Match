export default defineAppConfig({
    ui: {
      primary: "sky",
      gray: "cool",
      card: {
        divide: "divide-y divide-gray-200 dark:divide-gray-600",
        ring: "ring-1 ring-gray-200 dark:ring-gray-600",
  
        shadow: "shadow-lg dark:shadow-gray-700 dark:shadow-lg",
        header: {
          padding: "px-4 py-3 sm:px-6",
        },
      },
      badge: {
        size: {
          xl: "text-lg px-5 py-1.5",
        },
      },
    
      modal: {
        container: "flex min-h-full items-center justify-center text-center",
      },
    },
  });
  