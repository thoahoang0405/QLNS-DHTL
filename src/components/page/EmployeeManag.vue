<template>
  <div class="body">
    <h3 class="header-bd">Quản lý sinh viên</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" placeholder="Tìm kiếm sinh viên" />
          <div class="icon-search icon"></div>
        </div>
        <div class="input">
          <input
            type="text"
            id="filter"
            class="filter"
            placeholder="Lọc theo vị trí"
          />
          <div class="icon-filter icon"></div>
          <div class="icon-cbb">
            <div class="icon icon-down-bold hiddenCbb"></div>
          </div>
        </div>
        <div class="input">
          <input type="text" class="filter" placeholder="Lọc theo phòng ban" />
          <div class="icon-filter icon"></div>
          <div class="icon icon-down-bold"></div>
        </div>
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
              <th>Tên ngân hàng</th>
              <th>Địa chỉ</th>
              <th>Khoa</th>
              <th>Trạng thái</th>
              <th>Cấp bậc lương</th>
              <th>Phòng ban</th>
              <th>Chứng chỉ đào tạo</th>
              <th>Tình trạng hôn nhân</th>
              <th>Khen thưởng</th>
              <th>Kỷ luật</th>
              <th>Tên tài khoản</th>
              <th>Mật khẩu</th>
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
          <tr ref="row">
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
            <td class="text-center">1</td>
            <td>1951061106</td>
            <td>Ngô Văn Tùng</td>
            <td>Nam</td>
            <td>18/03/2001</td>
            <td>9999999999</td>
            <td>ngotung180301@gmail.com</td>
            <td>0393072588</td>
            <td>8888888888</td>
            <td>8686868686</td>
            <td>MB Bank</td>
            
            <td>Bắc Ninh</td>
            <td>Công nghệ thông tin</td>
            <td></td>
            <td></td>
            <td></td>
            <td>Đại học</td>
            <td></td>
            <td></td>
            <td></td>
            <td>admin</td>
            <td>admin</td>
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
<Form v-show="isShow" @hideForm="closeForm"></Form>
</template>
<style>
  .btn-add:hover {
    opacity: 0.8;
  }
</style>
<script>
import Paginate from "vuejs-paginate-next";
import Form from "../base/FormEmployee.vue"
import $ from "jquery";
export default {
  components: {
    Paginate,Form
  },
  data() {
    return {
      isActive: "10",
      pageNumber: 1,
      page: 1,
      totalPage: 0,
      isShow: false, //gán v-show=isShow hoặc v-show =false để ẩn form
      isShowDrop: false,

      pageDefault: 10,
    };
  },
  methods: {
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
      this.filterEmployee();
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },

    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.filterEmployee();
    },
  },
};
</script>
