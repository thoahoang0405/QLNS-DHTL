<template>
    <div id="form">
      <form class="form">
        <div class="form-top">
          <div class="form-title">
            <h3 class="title">Thêm/sửa thông tin tuyển dụng</h3>
            <span class="close" @click="closeFormRecruit">X</span>
          </div>
        </div>
        <div class="form-Wrap">
          <div class="column">
            <div class="input__box">
              <label for="">Image</label>
              <input class="manv" type="file" />
              <!-- <div class="invalid-feedback" v-if="errors.manv">
                {{ errors.manv }}
              </div> -->
            </div>
          </div>

          <div class="column">
            <div class="input__box">
              <label for="">Tiêu đề</label>
              <input class="ten" type="text" v-model="recruit.Title"/>
              <!-- <div class="invalid-feedback" v-if="errors.ten">
                {{ errors.ten }}
              </div> -->
            </div>
            <div class="input__box">
              <label for="">Văn bằng</label>
              <input class="manv" type="text" v-model="recruit.Experience"/>
              <!-- <div class="invalid-feedback" v-if="errors.manv">
                {{ errors.manv }}
              </div> -->
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Khoa</label>
              <input class="ten" type="text" v-model="recruit.DepartmentOfWork"/>
              <!-- <div class="invalid-feedback" v-if="errors.ten">
                {{ errors.ten }}
              </div> -->
            </div>
            <div class="input__box">
              <label for="">Bậc lương</label>
              <input class="ten" type="text" v-model="recruit.Salary"/>
              <!-- <div class="invalid-feedback" v-if="errors.ten">
                {{ errors.ten }}
              </div> -->
            </div>
          </div>

          
        </div>
        <div class="form-bottom">
          <div class="btn btn-cancel" @click="closeFormRecruit">Hủy</div>
          <div class="btn btn-save" @click="save">Lưu</div>
        </div>
      </form>
      <!-- <notifi
        v-show="isShowNotifi"
        @closeNotifi="closeNo"
        @cancelNotifi="FormCancel"
      ></notifi> -->
    </div>
  
    <!-- thongbao -->
  </template>
  
  <script>
  // import notifi from "./FormNotifi.vue"
  // import combobox from "../base/BaseCombobox.vue";
  import axios from "axios";
  import { useToast } from "vue-toastification";
  
  
  export default {
    data() {
      return {
        isShow: false,
        recruit: {},
        formMode: 1,

      };
    },
    props: ["RecruitSL","recruitID"],
    components: {
      // combobox,
    },
    watch: {
    RecruitSL: function(value){
        this.recruit=value
        this.recruit.RecruitmentID=value.RecruitmentID
    },
    FormMode: function(value){
        this.formMode=value
    },
    
  },
    methods: { 
      addRecruit(){
          var me = this;
          console.log(me.recruit);
          me.recruit.Gender=parseInt( me.recruit.Gender)
        const toast = useToast();
        try {
          axios
            .post("https://localhost:7029/api/Recruitment", me.recruit)
            .then(function (res) {
              console.log("ok", res.data);
              me.recruit={}
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              // me.loadData()
            })
          
            .catch(function () {
              toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      },

      editRecruit(){
        var me = this;
        const toast = useToast();
        try {
          axios
            .put(`https://localhost:7029/api/Employees/${this.recruit.RecruitmentID}`, me.recruit)
            .then(function (res) {
              console.log("ok", res.data);
              me.$emit("hideForm", false);
              toast.success("Sửa dữ liệu thành công", { timeout: 2000 });
            })
          
            .catch(function () {
              toast.error("Sửa dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      },

      closeFormRecruit() {
        this.$emit("hideForm", false);
        this.errors = {
        };
      },
      save() {
        if(this.formMode==1){
            this.addRecruit()
        }else{
          this.editRecruit()
        }
      }
    }
  }
      
  
     
      
  </script>
  <style>
  label {
    margin: 10px 0;
  }
  label span{
    color: red;
  }
  .invalid-feedback {
    color: red;
    position: absolute;
    font-size: 12px;
    /* border: 2px solid red; */
  }
  #form {
    background-color: rgba(0, 0, 0, 0.2);
    z-index: 3;
    width: 100%;
    height: 100%;
    margin: auto;
    position: fixed;
    display: flex;
    /* display: none; */
  }
  #form input {
    max-width: 100%;
    max-height: 26px;
    padding-bottom: 6px;
    border: 1px solid #ccc;
    border-radius: 2px;
    outline: none;
    position: relative;
    width: 100%;
    outline: none;
    padding-left: 5px;
    color: #707070;
    margin-top: 7px;
  }
  .form {
    width: fit-content;
    height: fit-content;
    background-color: #fff;
    margin: auto auto;
    border-radius: 8px;
    width: 800px;
    /* display: none; */
  }
  .form-Wrap {
    padding: 0 20px;
  }
  .form-title {
    padding: 0 13px;
    background-color: #d9d9d9;
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 0px;
  }
  .close {
    cursor: pointer;
    font-weight: 600;
    font-size: 18px;
    color: #726c6c;
  }
  .input__box {
    width: 100%;
    margin-bottom: 10px;
  }
  .form-bottom {
    display: flex;
    justify-content: flex-end;
    padding: 8px;
    background-color: #d9d9d9;
    gap: 28px;
    margin-top: 2px;
  }
  .btn-cancel {
    background-color: #fff;
  }
  .btn-save {
    background-color: #1a8fdd;
    color: #fff;
  }
  .btn {
    padding: 10px 30px;
    cursor: pointer;
    border-radius: 2px;
    height: 36px;
    align-items: center;
    box-sizing: border-box;
  }
  .column {
    display: flex;
    column-gap: 20px;
  }
  .radio__box {
    display: flex;
    align-items: center;
    margin-top: 8px;
    column-gap: 10px;
  }
  .radio__box input {
    width: 15px;
    margin: 0;
  }
    .important {
      color: red;
    }
  </style>
  