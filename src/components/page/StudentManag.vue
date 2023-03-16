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
            placeholder="Lọc theo kì học"
          />
          <div class="icon-filter icon"></div>
          <div class="icon-cbb">
            <div class="icon icon-down-bold hiddenCbb"></div>
          </div>
        </div>
        <div class="input">
          <input type="text" class="filter" placeholder="Lọc theo xếp loại" />
          <div class="icon-filter icon"></div>
          <div class="icon icon-down-bold"></div>
        </div>
      </div>
      <div class="button-function">
        <div class="add">
          <button @click="btnShow" class="btn-add btn-hover-blue">+ Thêm sinh viên</button>
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
            <th>Địa chỉ</th>
            <th>Khoa</th>
            <th>Kì học</th>
            <th>Khen thưởng</th>
            <th>Kỉ luật</th>
            <th>Học bổng</th>
            <th>Trạng thái</th>
            <th>Tên đăng nhập</th>
            <th>mật khẩu</th>
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
            <td>1951061039</td>
            <td>Hoàng Thị Thỏa</td>
            <td>Nữ</td>
            <td>04/05/2001</td>
             <td>038743874</td>
            <td>hoangthoa@gmail.com</td>
            <td>0827264382</td>
            <td>046576578</td>
            <td>Nam Định</td>
            <td>Công nghệ thông tin</td>

            <td>kì II-2022</td>
            <td>Sinh viên tiên tiến</td>
            <td></td>
            <td></td>
            <td>Đang học</td>
            <td>1951061039</td>
            <td>948388922</td>
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
    <!-- <div id="table">
        <div class="table">
          <table>
            <thead>
              <tr>
                <th class="text-center width-fit">
                  <input type="checkbox" />
                </th>

                <th class="stt">STT <div class="tooltip-stt">Số thứ tự</div>
                </th>

                <th>Mã sinh viên</th>
                <th>Họ và tên</th>
                <th>Giới tính</th>
                <th>Ngày sinh</th>
                <th>Số CMND/CCCD</th>
                <th>Email</th>
                <th>Số điện thoại</th>
                <th>Số tài khoản</th>
                <th>Địa chỉ</th>
                <th>Khoa</th>
                <th>Kì học</th>
                <th>Khen thưởng
                </th>
                <th>Kỉ luật</th>
                <th>Học bổng</th>
                <th>Trạng thái</th>
                <th>Tên đăng nhập</th>
                <th>mật khẩu</th>
                <th>Chức năng</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td class="text-center">
                  <input type="checkbox" />
                </td>
                <td class="text-center">1</td>
                <td>1951061039</td>
                <td>Hoàng Thị Thỏa</td>
                <td>Nữ</td>
                <td>04/05/2001</td>
                <td >hoangthoa@gmail.com</td>
                <td >0827264382</td>
                <td >046576578</td>
                <td >Nam Định</td>
                <td>Công nghệ thông tin</td>
                
                <td>kì II-2022</td>
                <td>Sinh viên tiên tiến</td>
                <td></td>
                <td></td>
                <td>Đang học</td>
                <td>1951061039</td>
                <td>948388922</td>
                <td>
                  <div class="function-table">
                    <div class="icon icon-edit"></div>
                    <div class="icon icon-delete"></div>
                  </div>
                </td>
              </tr>
      
            </tbody>
          </table>
          <div class="table-footer">
            <div class="tb-footer-left">
              <div class="total-record">
                Tổng số: <strong>200 </strong>bản ghi
              </div>

              <div class="paging-combobox">
                
                
                  <input type="text" class="page" placeholder="20">
                  <div class="icon icon-down-bold"></div>
                
              
              </div>
             
              <div class="paging">
                <div class="icon icon-prev"></div>
                <p>1</p>
                <strong>2</strong>
                <p>...</p>
                <p>100</p>
                <div class="icon icon-next"></div>
              </div>
            </div>
            <div class="tb-footer-right">
              <div class="total-count"><strong>10</strong></div>
              <div class="total-price"><strong>100.000.000</strong></div>
              <div class="total-price"><strong>100.000.000</strong></div>
              <div class="total-price"><strong>100.000.000</strong></div>
            </div>
          </div>
        </div>
      </div> -->
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
import Form from "../base/FormDetail.vue"
import $ from "jquery";
export default {
  components: {
    Paginate, Form
  },
  data() {
    return {
      isActive: "10",
      pageNumber: 1,
      page: 1,
      totalPage: 0,
      isShow: false, //gán v-show=isShow hoặc v-show =false để ẩn form
      isShowDrop: false,
      // isShowNotifi: false,
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
