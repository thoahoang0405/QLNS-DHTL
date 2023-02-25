<template>
    <div class="container">
      
      <the-menu  />
      <the-header />
      <router-view />
    </div>
  </template>
  
  <script>
  import TheHeader from "../TheHeader.vue";
  import TheMenu from "../TheMenu.vue";
  export default {
    components: {
      TheHeader,
      TheMenu,
    },
    data() {
      return {
        isZoom: false,
      };
    },
  };
  </script>
  
  <style scoped></style>
  