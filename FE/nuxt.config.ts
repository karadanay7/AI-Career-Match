// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-04-03',
  devtools: { enabled: true },
  modules: ["@nuxt/ui", "@nuxt/image", "@nuxtjs/supabase","@pinia/nuxt", "@pinia-plugin-persistedstate/nuxt"],
  css: ['~/assets/style.css'],
  ui: {
    global: true,
  },
  supabase: {
    redirect: false,
  },
  nitro: {
    compressPublicAssets: true,
  },
})