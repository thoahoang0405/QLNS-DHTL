<template>
  <div class="body">
    <h3 class="header-bd">Quản lý sinh viên</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search"   v-model="txtSearch"  @keypress.enter="getPagingEmployee"  placeholder="Tìm kiếm sinh viên" />
          <div class="icon-search icon"></div>
        </div>
        
        <Combobox
          :items="department"
         
          :fieldName="'DepartmentName'"
         
          @selectedItem="selectItemCbb"
        ></Combobox>
      
        <Combobox
          :items="position"       
          :fieldName="'PositionsName'"
          @selectedItem="selectItemCategory"
         
        ></Combobox>
      </div>
      <div class="button-function">
        <div class="add">
          <button @click="btnShow" class="btn-add btn-hover-blue">+ Thêm nhân viên</button>
        </div>

        <button class="btn-excel">
          <div class="icon icon-excel">
            <div class="tooltip-excel">Xuất ra excel</div>
          </div>
        </button>
        
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
            <th class="text-center" style="min-width: 40px;">STT</th>
              <th>Mã nhân viên</th>
              <th>Họ và tên</th>
              <th>Giới tính</th>
              <th>Ngày sinh</th>
              <th>Số CMND/CCCD</th>
              <th>Email</th>
              <th>Số điện thoại</th>
              <th>Mã số thuế</th>
              <th>Số tài khoản</th>
              <th>Địa chỉ</th>
              <td>Trạng thái</td>
              <th>Lớp</th>
              <th>Khoa</th>
              <th>Chương trình đào tạo</th>
              <th>Cấp bậc lương</th>
              <th>Phòng ban</th>
              <th>Chứng chỉ đào tạo</th>
              <th>Tình trạng hôn nhân</th>
              <th>Vị trí</th>
              
            <th
              class="th-item-final sticky-right-top"
              colspan="12"
              style="min-width: 100px; text-align: center"
            >
              <div class="th-item">
                <span class="table-text">Chức năng </span>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr ref="row" v-for="(emp, index) of employees" :key="emp.EmployeeCode">
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
<<<<<<< HEAD
            <td class="text-center">1</td>
            <td>1951061106</td>
            <td>Ngô Văn Tùng</td>
            <td>Nam</td>
            <td>18/03/2001</td>
            <td>9999999999</td>
            <td>ngotung180301@gmail.com</td>
            <td>0393072588</td>
            <td>8888888888</td>
            <td>Bắc Ninh</td>
            <td>Trạng thái</td>
            <td>61THNB</td>
            <td>Công nghệ thông tin</td>
            <td>Đại học</td>
            <td>1/1/2019</td>
            <td>1/1/2024</td>
            <td></td>
=======
            <td class="text-center">{{ index+1 }}</td>
            <td>{{ emp.EmployeeCode }}</td>
            <td>{{ emp.EmployeeName }}</td>
            <td>{{ emp.Gender }}</td>
            <td>{{ formatDate(emp.DateOfBirth) }}</td>
            <td>{{ emp.IdentityNumber }}</td>
            <td>{{ emp.Email }}</td>
            <td>{{ emp.Phonenumber }}</td>
            <td>{{ emp.TaxCode }}</td>
            <td>{{ emp.BankAccountNumber }}</td>
            <td>{{ emp.BankAccountName }}</td>
            
            <td>{{ emp.Adress }}</td>
            <td>{{ emp.FacultyName }}</td>
            <td>{{ emp.StatusEmployeeName }}</td>
            <td>{{ emp.SalaryName }}</td>
            <td>{{ emp.DepartmentName }}</td>
            <td>{{ emp.TrainingCertificateName}}</td>
            <td>{{ emp.MaritalStatus }}</td>
            <td>{{ emp.PositionsName }}</td>
           
>>>>>>> 5f8984661eb528802f019a70064751e15f3d9bfe
            <td
              ref="func"
              class="td-item-final td-func sticky-right"
              style="position: sticky; right: 0; background-color: #fff"
              colspan="12"
            >
              <div class="edit-text"></div>
              <div class="icon icon-edit"></div>
                <div class="icon icon-delete"></div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="paging">
      <div class="paging-left">
        Tổng số:
        <strong>{{ totalRecord }}</strong>
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
                
                @click="getPageDefault"
              >
                10 bản ghi trên 1 trang
              </div>
              <div
                class="item-dropup"
                :class="{ act: isActive == '20' }"
                pageSize="20"
                @click="getPageDefault"
                :value="pageDefault"
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
          v-model="page"
                    :page-count="totalPage"
                    :page-range="2"
                    :margin-pages="1"
                    :click-handler="clickCallback"
                    :prev-link-class="'page-link'"
                    :prev-text="'Trước'"
                    :prev-class="'page-item'"
                    :next-link-class="'page-link'"
                    :next-text="'Sau'"
                    :next-class="'page-item'"
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
<style>
  .btn-add:hover {
    opacity: 0.8;
  }
  .border-red {
  border: 1px solid red;
  }
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
</style>
<script>
import Paginate from "vuejs-paginate-next";
import axios from "axios";
import Form from "../base/FormEmployee.vue"
import $ from "jquery";
import Combobox from "../base/BaseCombobox2.vue";
export default {
  components: {
    Paginate,Form,Combobox
  },
  data() {
    return {
      isActive: "20",
      pageNumber: 1,
      page: 1,
      employees:{},
      totalPage: 1,
      isShow: false, //gán v-show=isShow hoặc v-show =false để ẩn form
      isShowDrop: false,
      totalRecord: 0,
      pageDefault: 20,
      department:{},
      position:{},
      departmentID:"",
      positionID:"",
      txtSearch:"",
    };
  },
  created() {
    this.getPagingEmployee()
    this.getDepartment()
    this.getPosition()
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getPagingEmployee();
      }
    },
  },
  methods: {

    getPagingEmployee() {
      try {
       
        var me = this;
       
        axios
          .get(
            `https://localhost:44301/api/Employees/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&departmentID=${this.departmentID}&positionID=${this.positionID}&pageNumber=${this.pageNumber}`
          )
          .then(function (res) {
          
            me.totalPage = res.data.TotalPages;
            me.totalRecord = res.data.TotalRecords;
            me.employees = res.data.Data;
            console.log( me.totalPage);
            console.log(me.employees);
            
          })
         
          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getDepartment(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api/Departments"
         )
         .then(function (res) {
          me.department=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }

    },
    getPosition(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api/Position"
         )
         .then(function (res) {
          me.position=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }

    },
    formatDate(date) {
      try {
        if (date) {
          date = new Date(date);
          let newDate = date.getDate();
          let month = date.getMonth() + 1;
          let year = date.getFullYear();
          newDate = newDate < 10 ? `0${newDate}` : newDate;
          month = month < 10 ? `0${month}` : month;
          return `${newDate}-${month}-${year}`;
        }
      } catch (error) {
        return "";
      }
    },
    selectItemCbb(value) {
    
      if (value.DepartmentID) {
        this.departmentID = value.DepartmentID;
      } else {
        this.departmentID = "";
        this.getPagingEmployee();
      }
      this.getPagingEmployee();
     
    },
    selectItemCategory(value) {
      console.log(value.PositionsID);
      if (value.PositionsID) {
        this.positionID = value.PositionsID;
        
      } else {
        this.positionID= "";
        this.getPagingEmployee();
      }
      this.getPagingEmployee();
    },
    showPage(is) {
      this.isShowDrop = is;
    },
    btnShow(){
      this.isShow = !this.isShow
    },
    //nhận lệnh ẩn từ bên form chi tiết
    closeForm(value){
      this.isShow=value
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
      this.getPagingEmployee()
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },

    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.getPagingEmployee()
    },
  },
};
</script>
