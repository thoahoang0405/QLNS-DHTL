<template>
  <div class="body">
    <h3 class="header-bd">Quản lý tuyển dụng</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" placeholder="Tìm kiếm " />
          <div class="icon-search icon"></div>
        </div>
      </div>
      <div class="button-function">
        <div class="add">
          <button @click="btnShowRecruit" class="btn-add btn-hover-blue">+ Thêm tin tuyển dụng</button>
        </div>
        <button @click=" getRecruitment" class="btn-excel">
          <div class="icon icon-load">
            <div class="tooltip-excel">Lấy lại dữ liệu</div>
          </div>
        </button>
        
        <!-- <button class="btn-excel">
          <div class="icon icon-excel">
            <div class="tooltip-excel">Xuất ra excel</div>
          </div>
        </button> -->
      </div>
    </div>
    <div id="body-recruit">
      <div class="body-recruit" >
     
      <div class="item-row" >
        <div class="item-recruit" v-for="item of recruitment" :key="item.RecruitmentID" style="display:flex; flex-wrap: wrap;">
          <div class="body-rec">
            <div >
              <img v-if="item.DepartmentOfWork=='Công nghệ thông tin'" class="image" src="@/assets/img/anh7.png" alt="" />
            </div>
            <div>
              <img v-if="item.DepartmentOfWork=='Kinh tế'" class="image" src="../../assets/img/anh2.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">{{ item.Title }}</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: {{ item.Experience }}</div>
              <div>Khoa: {{ item.DepartmentOfWork }}</div>
              <div>Bậc lương: {{ item.Salary }}</div>
              <div class="btn-wrap">
                <div class="btnEdit" @click="editRecruit(rec)">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        

      </div>
     </div>
    </div>
  </div>
 <FormRecruitManag v-show="isShow" @hideForm="closeFormRecruit" :RecruitSL="RecruitSelect" :recruitID="recruitID"></FormRecruitManag>
</template>
<style scoped>
.body-header {
 height: 60px;
 box-sizing: border-box;
}
#body-recruit {
  margin: 0 auto;
  width: 100%;
 height: calc(100% - 120px);
 background-color: #e7e7e7;
}
.body-recruit{
  height: 100%;
  width: 100%;
  overflow-y: scroll;
}
.item-row{
  display: flex;
  align-items: center;
  flex-wrap: wrap;
  justify-content: center;
}
/* .item-row {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
  /* justify-content: space-between; */
  /* flex-wrap: wrap; */


.item-recruit {
  border-radius: 4px;
  width: 276px;
  background-color: #fff;
  padding: 8px;
  margin: 8px 8px;
  /* height: 310px; */
  /* overflow-y: hidden; */
}
.image {
  border-radius: 4px;
  width: 100%;
  height: 100%;
}
.title-name {
  margin-bottom: 10px;
}
.btn-wrap {
  display: flex;
  justify-content: flex-end;
  column-gap: 10px;
  margin-top: 10px;
} 
.btnEdit{
  background-color: #1aa4c8;
    color: #fff;
    padding: 6px 8px;
  border-radius: 2px;
  cursor: pointer;
}
.btnEdit:hover{
  background-color: #fff;
    color: #1aa4c8;
    border: 1px solid #1aa4c8;
}
.btnDelete {
  border: 1px solid #e25656;
  padding: 6px 8px;
  border-radius: 2px;
  cursor: pointer;
  background-color: #fff;
  color: #e25656;
}
.btnDelete:hover{
  background-color: #e25656;
  color: #fff;
}

/* @media screen and (max-width: 767.98px) {
  .item-row{
    display: grid;
    grid-template-columns: repeat(2,1fr);
}
}
@media screen and (max-width: 600px) {
  .item-row{
    display: grid;
    grid-template-columns: 1fr;
}
} */
</style>

<script>
import FormRecruitManag from '../base/FormRecruitManag.vue'
import axios from 'axios';

export default {
  components: {
    FormRecruitManag
  },
  data() {
    return {
      isShow: false,
      recruitment: {},
      formMode: 1,
      RecruitSelect:{},
      recruitID:"",
    };
  },
  created() {
    this.getRecruitment()
  },
  methods:{
    editRecruit(rec){
      this.RecruitSelect=rec
      this.recruitID=rec.RecruitmentID
     this.isShow=true
     this.formMode=2
    },
    closeFormRecruit(value){
      this.isShow=value
    },
    btnShowRecruit(){
      this.isShow = !this.isShow
    },
    getRecruitment(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:7029/api/Recruitment"
         )
         .then(function (res) {
          me.recruitment=res.data
          for (const iterator of res.data) {
              console.log(iterator.Benefit);
          }
         })
        
         .catch(function () {
          //  console.log(1);
         });
     } catch (error) {
       console.log(error);
     }
    }
  }
};
</script>
