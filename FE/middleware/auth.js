export default defineNuxtRouteMiddleware((from, to) => {
    const user = useSupabaseUser();
  
    if (!user.value && to.fullPath == "/register") {
      return navigateTo("/auth");
    }
    // We will fix here later to add our own logic
  });
  