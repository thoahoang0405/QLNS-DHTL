<template>
  <div class="body">
    <h3 class="header-bd">Quản lý sinh viên</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" v-model="txtSearch"  @keypress.enter="getpagingStudent" placeholder="Tìm kiếm sinh viên" />
          <div class="icon-search icon"></div>
        </div>
        <Combobox
          :items="faculty"
         
          :fieldName="'FacultyName'"
         
          @selectedItem="selectItemCbb"
        ></Combobox>
      
        <Combobox
          :items="classification"       
          :fieldName="'Classification'"
          @selectedItem="selectItemCategory"
         
        ></Combobox>
      </div>
      <div class="button-function">
        <div class="add">
          <button @click="btnAddStudent" class="btn-add btn-hover-blue">+ Thêm sinh viên</button>
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
            <th>Mã sinh viên</th>
            <th>Họ và tên</th>
            <th>Giới tính</th>
            <th>Ngày sinh</th>
            <th>Số CMND/CCCD</th>
            <th>Email</th>
            <th>Số điện thoại</th>
            <th>Số tài khoản</th>
            <th>Tên ngân hàng</th>
            <th>Địa chỉ</th>
            <th>Khoa</th>
            <th>Lớp</th>
            <th>Chương trình đào tạo</th>
            <th>Xếp loại</th>
            <th>Trạng thái</th>
           
          
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
          <tr ref="row" v-for="(item,index) in students" :key="item.StudentID" @dblclick="btnEditStudent(item)" >
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
            <td class="text-center">{{ index+1 }}</td>
            <td>{{ item.StudentCode }}</td>
            <td>{{ item.StudentName }}</td>
            <td>{{ gender(item.Gender) }}</td>
            <td>{{ formatDate(item.DateOfBirth) }}</td>
             <td>{{ item.IdentityNumber }}</td>
            <td>{{ item.Email }}</td>
            <td>{{ item.Phonenumber }}</td>
            <td>{{ item.BankAccountNumber }}</td>
            <td>{{ item.BankAccountName}}</td>
            <td>{{ item.Adress }}</td>
            <td>{{ item.FacultyName }}</td>
            <td>{{ item.Class}}</td>
            <td>{{ item.EducationProgramName }}</td>       
            <td>{{ item.ClassificationName }}</td>       
            <td>{{ item.StatusName }}</td>
           
            <td
              ref="func"
              class="td-item-final td-func sticky-right"
              style="position: sticky; right: 0; background-color: #fff"
              colspan="12"
            >
              <div class="edit-text"></div>
              <div class="icon icon-edit" @click="btnEditStudent(item)"></div>
                <div class="icon icon-delete" @click="deleteClick(item)"></div>
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
<Form v-show="isShowForm" @hideForm="hideFormDetail" :code="newCode" :loadData="getpagingStudent" :student="studentSelected"></Form>
<PopupConfirm :msv="msvDelete" v-show="isShowConfirm" @cancelNotifi="cancelConfirm"> </PopupConfirm>

</template>
<style scoped>
  .btn-add:hover {
    opacity: 0.8;
  }
  
</style>
<script>
import Paginate from "vuejs-paginate-next";
import Form from "../base/FormDetail.vue"
import PopupConfirm from "../base/BasePopupDelete.vue"
import $ from "jquery";
import Combobox from "../base/BaseCombobox2.vue";
import axios from "axios";
export default {
  components: {
    Paginate,Form,PopupConfirm,Combobox
  },
  data() {
    return {
   
      isActive: "20",
      studentSelected: [],
      pageNumber: 1,
      page: 1,
      totalPage: 0,
      isShowConfirm: false,
      isShowForm: false,
      isShow: false, //gán v-show=isShow hoặc v-show =false để ẩn form
      isShowDrop: false,
      students:{},
      pageDefault: 20,
      msvDelete: "",
      faculty:{},
      facultyID: "",
      classification:{},
      classificationID:"",
      txtSearch:"",
      newCode: "",
    };
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
    this.getDepartment()
    this.getPosition()
  },
  methods: {
    getpagingStudent() {
      try {
       
        var me = this;
       
        axios
          .get(
            `https://localhost:7029/api/Students/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&facultyID=${this.facultyID}&classificationID=${this.classificationID}&pageNumber=${this.pageNumber}`
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
    gender(gender){
      switch (gender) {
        case 0:
          gender="Nam"
          break;
          case 1:
            gender="Nữ"
          break;
        default:
          break;
      }
      return gender;
    },
    getDepartment(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:7029/api/Faculty"
         )
         .then(function (res) {
          me.faculty=res.data
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
          "https://localhost:7029/api/Classifications"
         )
         .then(function (res) {
          me.classification=res.data
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
    
      if (value.FacultyID) {
        this.facultyID = value.FacultyID;
      } else {
        this.facultyID = "";
        this.getpagingStudent();
      }
      this.getpagingStudent();
     
    },
    selectItemCategory(value) {
      console.log(value.ClassificationID);
      if (value.ClassificationID) {
        this.classificationID = value.ClassificationID;
        
      } else {
        this.classificationID= "";
        this.getpagingStudent();
      }
      this.getpagingStudent();
    },
    clickAdd(item) {
      this.list.push(item)
    },
    showPage(is) {
      this.isShowDrop = is;
    },
    btnAddStudent(){
      this.isShowForm = !this.isShowForm;
      this.getNewCode()
    },
    getNewCode() {
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/Students/NewCode")
          .then(function (res) {
            me.newCode = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    btnEditStudent(item){
      this.isShowForm = !this.isShowForm;
      this.studentSelected=item
    },
    deleteClick(item){
      this.isShowConfirm=!this.isShowConfirm;
      console.log(item.msv);
      this.msvDelete=item.msv

    },
    cancelConfirm(value){
      this.isShowConfirm=value
    },
    //nhận lệnh ẩn từ bên form chi tiết
    closeFormDetail(value){
      console.log(value);
      this.isShow=value
    },
    hideFormDetail(value){
this.isShowForm=value
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
