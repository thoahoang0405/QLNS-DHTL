
<template>
  <div class="menu">
    <div class="menu-top">
      <router-link to="/" class="brand" @click="activeNumber = -1">
       
        <img src="../assets/icon/Logo-DH-Thuy-Loi.webp" style="width: 50px" alt="">
        <h1 class="brand-text" v-if="isZoomOut">QLNS</h1>
      </router-link>
      <ul class="navbar">
        <div v-for="item in items" :key="item" class="nav-item">
          <router-link
            class="nav-item-parent"
            @click="
              item.openChild = !item.openChild;
              activeTo = item.to;
            "
            :to="item.to"
            :class="activeTo === item.to ? 'active' : ''"
          >
            <div class="icon">
              <div :class="item.icon"></div>
            </div>
            <div class="nav-item-text" >{{ item.name }}</div>
           
          </router-link>
          
        </div>
      </ul>
    </div>
    <!-- <div class="menu-bottom">
      <button class="btn zoom-in" id="zoom" @click="zoomNavbar">
        <div class="btn-icon center">
          <div :class="isZoomOut ? 'icon-left' : 'icon-right'"></div>
        </div>
      </button>
    </div> -->
  </div>
</template>
<script>
export default {
  data() {
    return {
      isZoomOut: true,
      activeTo: "",
      items: [
      
        {
          icon: "icon-student",
          name: "Quản lý sinh viên",
    
          dropdown: false,
          to: "/sinhvien",
        },
        {
          icon: "icon-user",
          name: "Quản lý nhân viên",
          openChild: false,
          dropdown: true,
          to: "/nhanvien",
        
        },
        {
          icon: "icon-bonus",
          name: "Khen thưởng, kỷ luật",
          dropdown: true,
          to: "/thuong",
        },
        {
          icon: "icon-recruiter",
          name: "Quản lý tuyển dụng",
          dropdown: true,
          to: "/tuyendung",
        },
        {
          icon: "icon-document",
          name: "Quản lý hợp đồng",
          dropdown: false,
          to: "/hopdong",
        },
       
      ],
    };
  },
  methods: {
    
    zoomNavbar() {
      this.isZoomOut = !this.isZoomOut;
      this.$emit("zoomNavbar");
    },
  },
};
</script>
