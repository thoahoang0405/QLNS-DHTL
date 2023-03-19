<template>
    <div class="body">
      <div class="popup-bonus" v-if="isOpenPopupPunish">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thêm mới thông tin Kỷ Luật</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupPunish = false">
              <div class="icon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                  class="w-6 h-6"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
            </div>
          </div>
  
          <table>
            <tr>
              <td width="20%">Khối <span class="color-red">*</span></td>
              <td>
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
              <td width="10%">Lớp <span class="color-red">*</span></td>
              <td colspan="2">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Học sinh <span class="color-red">*</span></td>
              <td colspan="4">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Hình thức kỷ luật <span class="color-red">*</span></td>
              <td colspan="4">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Nơi kỷ luật <span class="color-red">*</span></td>
              <td colspan="4">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Ngày kỷ luật <span class="color-red">*</span></td>
              <td><input type="date" name="" id="" /></td>
              <td>
                <input type="checkbox" name="" id="" />
              </td>
              <td colspan="2">Được lưu vào học bạ</td>
            </tr>
            <tr>
              <td>Nội dung kỷ luật <span class="color-red">*</span></td>
              <td colspan="4">
                <input type="text" name="" id="" />
              </td>
            </tr>
            <tr>
              <td class="btn-group" colspan="5">
                <button class="btn-action">Lưu</button>
                <button @click="thongbao" class="btn-action">Đóng</button>
              </td>
            </tr>
          </table>
        </div>
      </div>
  
  
  
      <!-- end open popup ky luat   -->
      <div class="popup-bonus" v-if="isOpenPopupBonus">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thêm mới thông tin khen thưởng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupBonus = false">
              <div class="icon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                  class="w-6 h-6"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
            </div>
          </div>
  
          <table>
            <tr>
              <td width="20%">Khối <span class="color-red">*</span></td>
              <td>
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
              <td width="10%">Lớp <span class="color-red">*</span></td>
              <td colspan="2">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Học sinh <span class="color-red">*</span></td>
              <td colspan="4">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Hình thức khen thưởng <span class="color-red">*</span></td>
              <td colspan="4">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Nơi khen thưởng <span class="color-red">*</span></td>
              <td colspan="4">
                <select class="w-full" name="" id="">
                  <option value="1">Lựa chọn</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </td>
            </tr>
            <tr>
              <td>Ngày khen thưởng <span class="color-red">*</span></td>
              <td><input type="date" name="" id="" /></td>
              <td>
                <input type="checkbox" name="" id="" />
              </td>
              <td colspan="2">Được lưu vào học bạ</td>
            </tr>
            <tr>
              <td>Nội dung khen thưởng <span class="color-red">*</span></td>
              <td colspan="4">
                <input type="text" name="" id="" />
              </td>
            </tr>
            <tr>
              <td class="btn-group" colspan="5">
                <button class="btn-action">Lưu</button>
                <button @click="thongbao" class="btn-action">Đóng</button>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <h3 class="header-bd">Khen thưởng / Kỷ Luật</h3>
      <div class="body-header">
        <div class="row-input">
          <div class="input">
            <input type="text" class="search" placeholder="Tìm kiếm"  v-model="txtSearch"  @keypress.enter="getPagingEmployee"  />
            <div class="icon-search icon"></div>
          </div>
         
          
        </div>
     
      </div>
      <div id="m-table" class="m-table">
        <table id="tbEmployee" class="table">
          <thead>
            <tr>
              <th
                class="sticky-left-top checkbox"
                colspan="1"
                style="min-width: 30px !important; text-align: center"
              >
                <input
                  ref="checkall"
                  type="checkBox"
                  class="check-all"
                  style="width: 18px; height: 18px"
                />
              </th>
              <th class="text-center" style="min-width: 40px">STT</th>
              <th>Mã sinh viên viên</th>
              <th>Họ và tên</th>
             
              <th>Ngày sinh</th>
              <th>Giới tính</th>
              <th>Khoa</th>
              <th>Lớp</th>
              <th>Xếp loại</th>
             
              <th
                class="th-item-final sticky-right-top"
                colspan="12"
                style="min-width: 100px; text-align: center"
              >
                <div class="th-item">
                  <span class="table-text">Thêm khen thưởng/kỉ luật</span>
                </div>
              </th>
           
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item,i) of students" :key="item.StudentID" ref="row">
              <td
                ref="rowCheck"
                class="checkbox sticky-left"
                style="text-align: center"
                colspan="1"
              >
                <input
                  ref="check"
                  class="check-item"
                  type="checkbox"
                  style="width: 18px; height: 18px"
                />
              </td>
              <td class="text-center">{{ i+1 }}</td>
              <td>{{ item.StudentCode }}</td>
              <td>{{ item.StudentName }}</td>
              <td>{{ item.DateOfBirth }}</td>
              <td>{{ item.Gender }}</td>
              <td>{{ item.FacultyName }}</td>
              <td>{{ item.Class }}</td>
              <td>{{ item.ClassificationName }}</td>
              
              <td
                ref="func"
                class="td-item-final td-func sticky-right"
                style="position: sticky; right: 0; background-color: #fff; width: auto;"
                colspan="12"
              >
                <div class="edit-text"></div>
                <button class="bonus"  @click="OpenPopupPunish()">
                 Thêm khen thưởng
                </button>
                <button class="dis" @click="OpenPopupBonus()">
                Thêm  kỉ luật
                </button>
              </td>
              
            </tr>
          </tbody>
        </table>
      </div>
      <div class="paging">
        <div class="paging-left">
          Tổng số:
          <strong>200</strong>
          bản ghi
        </div>
        <div class="paging-right">
          <div class="page">
            <div class="content-page">{{ pageDefault }} bản ghi trên 1 trang</div>
            <div class="dropup-page">
              <div class="icon-dropup" @click="btnDropUp"></div>
              <div class="item-up" v-show="isShowDrop">
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '10' }"
                  pageSize="10"
                  :value="pageDefault"
                  @click="getPageDefault"
                >
                  10 bản ghi trên 1 trang
                </div>
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '20' }"
                  pageSize="20"
                  @click="getPageDefault"
                >
                  20 bản ghi trên 1 trang
                </div>
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '30' }"
                  pageSize="30"
                  @click="getPageDefault"
                >
                  30 bản ghi trên 1 trang
                </div>
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '50' }"
                  pageSize="50"
                  @click="getPageDefault"
                >
                  50 bản ghi trên 1 trang
                </div>
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '100' }"
                  pageSize="100"
                  @click="getPageDefault"
                >
                  100 bản ghi trên 1 trang
                </div>
              </div>
            </div>
          </div>
          <div>
            <Paginate
              v-model="pageNumber"
              :page-count="totalPage"
              :page-range="3"
              :margin-pages="1"
              :click-handler="clickCallback"
              :prev-text="'Trước'"
              :next-text="'Sau'"
              :container-class="'pagination'"
              :page-class="'page-item'"
            >
            </Paginate>
          </div>
        </div>
      </div>
    </div>
    <Form v-show="isShow" @hideForm="closeForm"></Form>
  </template>
  <script>
  import axios from "axios"
  import $ from "jquery"
  import Paginate from "vuejs-paginate-next";
  export default {
    data() {
      return {
        isOpenPopupBonus: false,
        isOpenPopupPunish: false,
        pageDefault:10,
        pageNumber: 1,
        txtSearch:"",
        totalPage:1,
        totalRecord:0,
        students:{},
        isShowDrop:false,

      };
    },
    components: {
      Paginate
    },
    watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getpagingStudent();
      }
    },
  },
  created(){
    this.getpagingStudent()
   
  },
    methods: {
      thongbao() {
        alert("Xác nhận đóng");
      },
      OpenPopupBonus() {
        this.isOpenPopupBonus = true;
      },
      OpenPopupPunish() {
        this.isOpenPopupPunish = true;
      },
      getpagingStudent() {
      try {
       
        var me = this;
       
        axios
          .get(
            `https://localhost:44301/api/Students/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&facultyID=${this.facultyID}&classificationID=${this.classificationID}&pageNumber=${this.pageNumber}`
          )
          .then(function (res) {
          
            me.totalPage = res.data.TotalPages;
            me.totalRecord = res.data.TotalRecords;
            me.students = res.data.Data;
            
           
            
          })
         
          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    showPage(is) {
      this.isShowDrop = is;
    },
    btnDropUp() {
      $(".icon-dropup").toggleClass("iconrotate");
      if (!this.isShowDrop) {
        this.showPage(true);
        $(".icon-dropup").addClass("iconrotate");
      } else {
        this.showPage(false);
        $(".icon-dropup").removeClass("iconrotate");
      }
    },
    getPageDefault(e) {
      this.isActive = e.target.getAttribute("pageSize");
      this.pageDefault = e.target.getAttribute("pageSize");
      this.showPage(false);
      $(".icon-dropup").removeClass("iconrotate");
      this.getpagingStudent();
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },

    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.getpagingStudent();
    },
    },
  };
  </script>
  <style scoped>
   ul.pagination {
    display: flex;
    color: #111;
    list-style-type: none;
}
ul.pagination a {
    text-decoration: none;
    color: #111;
    width: 200px ;
}
.content-page {
    min-width: 170px;
    margin-left: 6px;
    margin-right: 10px;
    margin-top: 9px;
    position: relative;
}
.page-link{
  margin: 5px;
}
.paging-left {
    color: #111;
    margin-left: 5px;
    margin-top: 20px;


    text-align: center;
}
.page-item:first-child {
 
 
  color: #727272;
}
.page-item:last-child {
 
  color: #727272;
}

.page-item {
  margin: 5px;
  width: 20px;
  height: 20px;
  display: flex;
  align-items: center;
  text-align: center;
  cursor: pointer;
  padding: 0;
  justify-content: center;
}

li.page-item.disabled {
  color: #bbb;
}
.page-item.active {
  font-weight: 700;
  text-align: center;
  background-color: #eeeaea;
  color: #000;
}

.page-item.active a {
  width: 20px;
  text-align: center;
}

.before-text {
  color: rgb(104, 102, 102);
  margin: 8px;
  margin-top: 10px;
}

.after-text {
  color: #111;
  margin: 8px;
  margin-top: 10px;
}
.page{
  margin-top: 10px;
  margin-right: 20px;
}
  .bonus-form {
    /* padding-left: 20px; */
  }
  table,
  tr,
  td {
    border: none;
    padding: 0px 5px 5px 5px;
    background-color: white;
    margin-top: 0px;
  }
  
  .width-half {
    width: 50%;
  }
  
  .color-red {
    color: red;
  }
  
  .btn-action {
    width: 100px;
    height: 50px;
    background: #3a98b9;
    margin-right: 10px;
    border: none;
    color: white;
    font-weight: bold;
    border-radius: 10px;
  }
  .btn-group {
    text-align: center;
  }
  .w-full {
    width: 100%;
    height: 35px;
  }
  .mask {
    position: relative;
    background-color: rgba(0, 0, 0, 0.5);
  }
  .popup-bonus {
    position: relative;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(0, 0, 0, 0.5);
    z-index: 2;
    cursor: pointer;
  }
  .bonus-form {
    position: absolute;
    width: 50vw;
    height: auto;
    margin: 0 auto;
    top: 15%;
    right: 15%;
    z-index: 99999;
    border-radius: 20px;
    box-shadow: 5px 5px 5px;
  }
  .title-heading {
    /* background-color: silver; */
  }
  /* tbody tr:hover {
    background-color: #9ed6e4 ;
  }
  tbody tr:hover .checkbox,
  tbody tr:hover .td-item-final {
    background-color: #9ed6e4 !important;
  } */
  .head-popup {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: white;
    margin-bottom: 0 !important;
  }
  svg:hover {
    color: red;
  }
  .btn-close-popup::hover {
    color: red !important;
  }
  table[data-v-07d000ee], tr[data-v-07d000ee], td[data-v-07d000ee] {
    border: none;
    padding: 0px 0px 5px 5px;
   
    margin-top: 0px;
}
  .sticky-right-top {
    position: sticky;
    z-index: 0;
    right: 0;
    top: 0;
    background-color: #ccf8e0;
}
.sticky-left-top {
    position: sticky;
    z-index: 0;
    left: 0;
    top: 0;
    background-color: #ccf8e0;
}
thead tr{
  background-color: #ccf8e0;
}
.bonus{
  padding: 2px 6px;
  font-size: 11px;
  height: 30px;
  box-sizing: border-box;
  min-width: 100px;
  margin-right: 4px;
  border-radius: 2.5px;
  background-color: #0cc71b;
  color: #f5f2f2;
  border: none;
  margin-top: 2px;
}
.bonus:hover{
  background-color: #ffff;
  color: #0fdb20;
  border: 1px solid #0fdb20;
}
.dis{
  padding: 2px 6px;
  font-size: 11px;
  height: 30px;
  box-sizing: border-box;
  min-width: 100px;
  margin-left: 4px;
  border-radius: 2.5px;
  background-color: #426cf7;
  color: #f5f2f2;
  border: none;
  margin-top: 2px;
}
.dis:hover{
  background-color: #ffff;
  color: #426cf7;
  border: 1px solid #426cf7;
}
tbody tr:hover .checkbox, tbody tr:hover .td-item-final{
  background-color: #fff !important;
}
  </style>
  