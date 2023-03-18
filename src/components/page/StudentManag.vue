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
          <tr ref="row" v-for="item in list" :key="item.id" @dblclick="btnEditStudent(item)" >
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
            <td class="text-center">{{ item.id }}</td>
            <td>{{ item.msv }}</td>
            <td>{{ item.ten }}</td>
            <td>{{ item.gioitinh }}</td>
            <td>{{ item.ngaysinh }}</td>
             <td>{{ item.cmnd }}</td>
            <td>{{ item.email }}</td>
            <td>{{ item.sodt }}</td>
            <td>{{ item.sotaikhoan }}</td>
            <td>{{ item.diachi }}</td>
            <td>{{ item.khoa }}</td>
            <td>{{ item.kyhoc }}</td>
            <td>{{ item.khenthuong }}</td>
            <td>{{ item.kyluat }}</td>
            <td>{{ item.hocbong }}</td>
            <td>{{ item.trangthai }}</td>
            <td>{{ item.tendangnhap }}</td>
            <td>{{ item.matkhau }}</td>
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
<Form v-show="isShowForm" @hideForm="hideFormDetail" :student="studentSelected"></Form>
<PopupConfirm :msv="msvDelete" v-show="isShowConfirm" @cancelNotifi="cancelConfirm"> </PopupConfirm>

</template>
<style>
  .btn-add:hover {
    opacity: 0.8;
  }
</style>
<script>
import Paginate from "vuejs-paginate-next";
import Form from "../base/FormDetail.vue"
import PopupConfirm from "../base/BasePopupDelete.vue"
import $ from "jquery";
export default {
  components: {
    Paginate,Form,PopupConfirm
  },
  data() {
    return {
      list: [
        {
          id: 1,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 2,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 3,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 4,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 5,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 6,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 7,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 8,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 9,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 10,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 11,
          msv: '1951061106',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
        {
          id: 12,
          msv: '999999999',
          ten: 'Ngô Văn Tùng',
          gioitinh: 'Nam',
          ngaysinh: '18/03/2001',
          cmnd: '038743874',
          email: 'ngotung@gmail.com',
          sodt: '9999999999',
          sotaikhoan: '8888888888',
          diachi: 'Bắc Ninh',
          khoa: 'Công nghệ thông tin',
          kyhoc: 'kì II-2022',
          khenthuong: '	Sinh viên tiên tiến',
          kyluat: '',
          hocbong: '',
          trangthai: 'Đang học',
          // ngaycap: '1/1/2019',
          // noicap: '1/1/2024',
          tendangnhap: '1951061106',
          matkhau: '1111111111',
        },
      ],
      isActive: "10",
      studentSelected: [],
      pageNumber: 1,
      page: 1,
      totalPage: 0,
      isShowConfirm: false,
      isShowForm: false,
      isShow: false, //gán v-show=isShow hoặc v-show =false để ẩn form
      isShowDrop: false,
      // isShowNotifi: false,
      pageDefault: 10,
      msvDelete: "",
    };
  },
  methods: {
    clickAdd(item) {
      this.list.push(item)
    },
    showPage(is) {
      this.isShowDrop = is;
    },
    btnAddStudent(){
      this.isShowForm = !this.isShowForm
    },
    btnEditStudent(item){
      this.isShowForm = !this.isShowForm
      this.studentSelected=item
    },
    deleteClick(item){
      this.isShowConfirm=!this.isShowConfirm
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
