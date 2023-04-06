<template>
  <!-- chuc vu -->
  <div class="body">
    <div class="popup-bonus" v-if="isOpenPopupPosition">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Chức vụ</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupPosition = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddPosition(item)">Thêm</div>
            <!-- <div class="btnEdit" @click="OpenPopupFormEditPosition(item)">Sửa</div> -->
          </div>
        </div>
        <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
          <tr>
            <th>Tên chức vụ</th>
            <th>Định mức giảng dạy</th>
            <th>Ngày bắt đầu</th>
            <th>Ngày kết thúc</th>
            <th style="width: 100px;">Chức năng</th>
          </tr>
          <tr>
          </tr>
          <tr v-for="item of chucvu" :key="item.IDChucVu">
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TenChucVu }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.DinhMucGiangDay }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.ThoiGianBatDau) }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.ThoiGianKetThuc) }}</td>
            <td ref="func" class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
              colspan="12">
              <div class="icon icon-edit" @click="OpenPopupFormEditPosition(item)"></div>
              <div class="icon icon-delete" @click="OpenPopupDeleteNotifi(item)"></div>
            </td>
          </tr>
        </table>
        <!-- <div class="btnDelete" style="bottom: -140px;">Xóa</div> -->
      </div>
    </div>
    <popUp v-show="isShowPopupPosition" :msv="mess" @cancelNotifi="noDelete" @closeNotifi="deletePosition"></popUp>

    <!-- them chuc vu -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddPosition">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Thêm chức vụ</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupAddNotifi = true">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>

        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="input__box">
              <label for="">Tên chức vụ <span>*</span></label>
              <input :class="errors.tenchucvu != '' ? 'border-red' : ''" @blur="validateName" type="text"
                v-model="suaChucVu.TenChucVu" />
              <div class="invalid-feedback" v-if="errors.tenchucvu != ''">
                {{ errors.tenchucvu }}
              </div>
            </div>
            <div class="input__box">
              <label for="">Thời gian bắt đầu</label>
              <input type="date" v-model="suaChucVu.ThoiGianBatDau" />
            </div>
            <div class="input__box">
              <label for="">Thời gian kết thúc</label>
              <input type="date" v-model="suaChucVu.ThoiGianKetThuc" />
            </div>
            <div class="input__box">
              <label for="">Định mức giảng dạy <span>*</span></label>
              <input :class="errors.dinhmucgiangday != '' ? 'border-red' : ''" @blur="validateNorm" type="text"
                v-model="suaChucVu.DinhMucGiangDay" />
              <div class="invalid-feedback" v-if="errors.dinhmucgiangday != ''">
                {{ errors.dinhmucgiangday }}
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupAddNotifi = true">Hủy</div>
        <div class="btnSave" @click="savePosition">Lưu</div>
      </div>
    </div>
    <!-- sua chuc vu-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditPosition">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Sửa chức vụ</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupEditNotifi = true">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="input__box">
              <label for="">Tên chức vụ</label>
              <input type="text" v-model="suaChucVu.TenChucVu" />
              <!-- <div class="invalid-feedback" v-if="errors.tenchucvu != ''">
                {{ errors.tenchucvu }}
              </div> -->
            </div>
            <div class="input__box">
              <label for="">Thời gian bắt đầu</label>
              <input type="date" v-model="suaChucVu.ThoiGianBatDau" />
            </div>
            <div class="input__box">
              <label for="">Thời gian kết thúc</label>
              <input type="date" v-model="suaChucVu.ThoiGianKetThuc" />
            </div>
            <div class="input__box">
              <label for="">Định mức giảng dạy</label>
              <input type="text" v-model="suaChucVu.DinhMucGiangDay" />
              <!-- <div class="invalid-feedback" v-if="errors.dinhmucgiangday != ''">
                {{ errors.dinhmucgiangday }}
              </div> -->
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifi = true">Hủy</div>
        <div class="btnSave" @click="btnEditPosition">Lưu</div>
      </div>
    </div>
    <!-- end open popup chuc vu   -->
    <!-- cảnh báo thêm chức vụ -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifi">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>

          <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupAddNotifi = false, isOpenPopupFormAddPosition = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifi = false">Không</div>
        </div>
      </div>
    </div>
    <!-- cảnh báo sửa chức vụ-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifi">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupEditNotifi = false, isOpenPopupFormEditPosition = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="isOpenPopupEditNotifi = false">Không</div>
        </div>
      </div>
    </div>
    <!-- cảnh báo xóa chức vụ-->
    <!-- <div class="notification-wrap" v-if="isOpenPopupDeleteNotifi">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">Thông tin chức vụ của sinh viên. Bạn có muốn xóa thông tin không?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupDeleteNotifi = false, isOpenPopupFormEditContract = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="isOpenPopupDeleteNotifi = false">Không</div>
        </div>
      </div>
    </div> -->
    <!-- hợp đồng -->
    <!-- hop dong -->
    <div class="popup-bonus" v-if="isOpenPopupContract">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Thông tin hợp đồng</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupContract = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <!-- <div class="btnEdit" @click="OpenPopupFormEditContract(item)">Sửa</div> -->
          </div>
        </div>
        <div class="formm">
          <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <tr>
              <th>Tên hợp đồng</th>
              <th>Ngày ký</th>
              <th>Ngày bắt đầu</th>
              <th>Ngày kết thúc</th>
              <th>Mô tả</th>
              <th style="width: 100px;">Chức năng</th>
            </tr>
            <tr>
            </tr>
            <tr v-for="item of hopdong" :key="item.IDHopDong">
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TenHD }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.NgayKi) }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.NgayBD) }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.NgayKT) }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.MoTa }}</td>
              <td ref="func" class="td-item-final td-func"
                style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
                colspan="12">
                <div class="icon icon-edit" @click="OpenPopupFormEditContract(item)"></div>
                <div class="icon icon-delete" @click="OpenPopupDeleteNotifiCV(item)"></div>
              </td>
            </tr>
          </table>
          <!-- <div class="btnDelete" style="bottom: -16px">Xóa</div> -->
        </div>

      </div>
    </div>
    <popUp v-show="isShowPopupContract" :msv="mess" @cancelNotifi="noDelete" @closeNotifi="deleteNotifiContract"></popUp>

    <!-- them hop dong -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddContract">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Thêm hợp đồng</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupAddNotifiCV = true">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="column">
              <div class="input__box">
                <label for="">Tên hợp đồng <span>*</span></label>
                <input :class="errors.tenhopdong != '' ? 'border-red' : ''" @blur="validateNameHD" type="text"
                  v-model="suaHopDong.TenHD" />
                <div class="invalid-feedback" v-if="errors.tenhopdong != ''">
                  {{ errors.tenhopdong }}
                </div>
              </div>
              <div class="input__box">
                <label for="">Ngày kí <span>*</span></label>
                <input :class="errors.ngayki != '' ? 'border-red' : ''" @blur="validateNgayKi" type="date"
                  v-model="suaHopDong.NgayKi" />
                <div class="invalid-feedback" v-if="errors.ngayki != ''">
                  {{ errors.ngayki }}
                </div>
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Ngày bắt đầu <span>*</span></label>
                <input :class="errors.ngaybatdau != '' ? 'border-red' : ''" @blur="validateNgayBD" type="date"
                  v-model="suaHopDong.NgayBD" />
                <div class="invalid-feedback" v-if="errors.ngaybatdau != ''">
                  {{ errors.ngaybatdau }}
                </div>
              </div>
              <div class="input__box">
                <label for="">Ngày kết thúc <span>*</span></label>
                <input :class="errors.ngayketthuc != '' ? 'border-red' : ''" @blur="validateNgayKT" type="date"
                  v-model="suaHopDong.NgayKT" />
                <div class="invalid-feedback" v-if="errors.ngayketthuc != ''">
                  {{ errors.ngayketthuc }}
                </div>
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Mô tả</label>
                <textarea v-model="suaHopDong.Mota" style="width: 100%;height: 60px;margin-top: 5px;"></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupAddNotifiCV = true">Hủy</div>
        <div class="btnSave" @click="saveContract">Lưu</div>
      </div>
    </div>
    <!-- sua hop dong-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditContract">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Sửa hợp đồng</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupEditNotifiCV = true">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="column">
              <div class="input__box">
                <label for="">Tên hợp đồng</label>
                <input type="text" v-model="suaHopDong.TenHD" />
                <!-- <div class="invalid-feedback" v-if="errors.tenhopdong != ''">
                  {{ errors.tenhopdong }}
                </div> -->
              </div>
              <div class="input__box">
                <label for="">Ngày kí</label>
                <input type="date" v-model="suaHopDong.NgayKi" />
                <!-- <div class="invalid-feedback" v-if="errors.ngayki != ''">
                  {{ errors.ngayki }}
                </div> -->
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Ngày bắt đầu</label>
                <input type="date" v-model="suaHopDong.NgayBD" />
                <!-- <div class="invalid-feedback" v-if="errors.ngaybatdau != ''">
                  {{ errors.ngaybatdau }}
                </div> -->
              </div>
              <div class="input__box">
                <label for="">Ngày kết thúc</label>
                <input type="date" v-model="suaHopDong.NgayKT" />
                <!-- <div class="invalid-feedback" v-if="errors.ngayketthuc != ''">
                  {{ errors.ngayketthuc }}
                </div> -->
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Mô tả</label>
                <textarea v-model="suaHopDong.Mota" style="width: 95%;height: 60px;margin-top: 5px;"></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifiCV = true">Hủy</div>
        <div class="btnSave" @click="btnEditContract">Lưu</div>
      </div>
    </div>
    <!-- end hop dong -->
    <!-- cảnh báo thêm hợp đồng -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifiCV">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupAddNotifiCV = false, isOpenPopupFormAddContract = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifiCV = false">Không</div>
        </div>
      </div>
    </div>
    <!-- cảnh báo xóa hợp đồng-->
    <!-- <div class="notification-wrap" v-if="isOpenPopupDeleteNotifiCV">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">Thông tin hợp đồng của sinh viên. Bạn có muốn xóa thông tin không?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupDeleteNotifiCV = false, isOpenPopupFormEditContract = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="deleteDeleteNotifiCV">Xóa</div>
        </div>
      </div>
    </div> -->
    <!-- cảnh báo sửa hợp đồng-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifiCV">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupEditNotifiCV = false, isOpenPopupFormEditContract = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="isOpenPopupEditNotifiCV = false">Không</div>
        </div>
      </div>
    </div>



    <h3 class="header-bd">Quản lý hợp đồng</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" placeholder="Tìm kiếm" v-model="txtSearch"
            @keypress.enter="getpagingStudent" />
          <div class="icon-search icon"></div>
        </div>
      </div>
    </div>
    <!-- table -->
    <div id="m-table" class="m-table">
      <table id="tbEmployee" class="table" style="width: 100%;">
        <thead>
          <tr>
            <!-- <th class="sticky-left-top checkbox" colspan="1" style="min-width: 30px !important; text-align: center">
              <input ref="checkall" type="checkBox" class="check-all" style="width: 18px; height: 18px" />
            </th> -->
            <th class="text-center" style="min-width: 40px">STT</th>
            <th>Mã nhân viên </th>
            <th>Họ và tên</th>
            <th>Ngày sinh</th>
            <th>Giới tính</th>
            <th>Gmail</th>
            <th>Chức vụ</th>
            <th>Hợp đồng</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, i) of students" :key="item.IDNhanVien" ref="row">
            <!-- <td ref="rowCheck" class="checkbox sticky-left" style="text-align: center" colspan="1">
              <input ref="check" class="check-item" type="checkbox" style="width: 18px; height: 18px" />
            </td> -->
            <td class="text-center">{{ i + 1 }}</td>
            <td>{{ item.MaNV }}</td>
            <td>{{ item.TenNV }}</td>
            <td>{{ formatDate(item.NgaySinh) }}</td>
            <td>{{ gender(item.GioiTinh) }}</td>
            <td>{{ item.Email }}</td>
            <td>
              <div class="desc" @click="OpenPopupPosition(item)">
                Xem chi tiết
              </div>
            </td>
            <td>
              <div class="desc" @click="OpenPopupContract(item)">
                Xem chi tiết
              </div>
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
              <div class="item-dropup" :class="{ act: isActive == '10' }" pageSize="10" :value="pageDefault"
                @click="getPageDefault">
                10 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '20' }" pageSize="20" @click="getPageDefault">
                20 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '30' }" pageSize="30" @click="getPageDefault">
                30 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '50' }" pageSize="50" @click="getPageDefault">
                50 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '100' }" pageSize="100" @click="getPageDefault">
                100 bản ghi trên 1 trang
              </div>
            </div>
          </div>
        </div>
        <div>
          <Paginate v-model="pageNumber" :page-count="totalPage" :page-range="3" :margin-pages="1"
            :click-handler="clickCallback" :prev-text="'Trước'" :next-text="'Sau'" :container-class="'pagination'"
            :page-class="'page-item'">
          </Paginate>
        </div>
      </div>
    </div>
  </div>
  <Form v-show="isShow" @hideForm="closeForm"></Form>
  <div id="load" v-show="isShowLoad">
    <div class="lds-ring">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  </div>
</template>
<script>
import axios from "axios"
import $ from "jquery"
import Paginate from "vuejs-paginate-next";
import { useToast } from "vue-toastification";
import popUp from "../base/BasePopupDelete2.vue"
export default {
  data() {
    return {
      isOpenPopupContract: false,
      isOpenPopupFostering: false,
      isOpenPopupPosition: false,
      isOpenPopupFormAddPosition: false,
      isOpenPopupFormEditPosition: false,
      isOpenPopupFormAddContract: false,
      isOpenPopupFormEditContract: false,
      isOpenPopupEditNotifi: false,
      isOpenPopupAddNotifi: false,
      isOpenPopupAddNotifiCV: false,
      isOpenPopupEditNotifiCV: false,
      isOpenPopupDeleteNotifiCV: false,
      isOpenPopupDeleteNotifi: false,
      pageDefault: 10,
      pageNumber: 1,
      txtSearch: "",
      totalPage: 1,
      totalRecord: 0,
      students: {},
      isShowDrop: false,
      dataSinhVienPunish: [],
      dataSinhVienBonus: {},
      chucvu: {},
      hopdong: {},
      isShowLoad: false,
      IDNV: "",
      MaNV: "",
      TenNV: "",
      suaChucVu: {},
      suaHopDong: {},
      mess: "",
      idDelete: "",
      isShowPopupContract: false,
      isShowPopupPosition: false,
      isValid: true,
      formMode: 1,
      errors: {
        tenchucvu: '',
        dinhmucgiangday: '',
        ngayki: '',
        tenhopdong: '',
        ngaybatdau: '',
        ngayketthuc: '',
      }
    };
  },
  components: {
    Paginate, popUp
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getpagingStudent();
      }
    },
  },
  created() {
    this.getpagingStudent()

  },
  methods: {
    gender(gender) {
      switch (gender) {
        case 0:
          gender = "Nam"
          break;
        case 1:
          gender = "Nữ"
          break;
        default:
          break;
      }
      return gender;
    },
    thongbao() {
      alert("Xác nhận đóng");
    },
    getContract() {
      try {

        var me = this;

        axios
          .get(
            `https://localhost:44301/api/hopdong/${this.IDNV}`
          )
          .then(function (res) {
            me.hopdong = res.data
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupContract(item) {
      this.isOpenPopupContract = true;
      this.MaNV = item.MaNV
      this.TenNV = item.TenNV
      this.IDNV = item.IDNhanVien
      this.getContract()
    },
    OpenPopupFostering(item) {
      this.isOpenPopupFostering = true;
      this.MaNV = item.MaNV
      this.TenNV = item.TenNV
    },
    getPosition() {
      try {

        var me = this;

        axios
          .get(
            `https://localhost:44301/api/chucvu/${this.IDNV}`
          )
          .then(function (res) {
            me.chucvu = res.data
            console.log(me.chucvu)
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },

    OpenPopupPosition(item) {
      this.isOpenPopupPosition = true;
      this.MaNV = item.MaNV
      this.TenNV = item.TenNV
      this.IDNV = item.IDNhanVien
      this.getPosition()
    },
    OpenPopupFormAddPosition() {
      this.isOpenPopupFormAddPosition = true;
      this.suaChucVu = {},
        this.suaChucVu.IDNhanVien = this.IDNV
    },
    btnAddPosition() {

      var me = this
      const toast = useToast();
      me.suaChucVu.IDNhanVien = me.IDNV
      console.log(me.suaChucVu);
      try {
        axios
          .post(
            "https://localhost:44301/api/chucvu", this.suaChucVu
          )
          .then(function (res) {
            console.log(res)
            me.isOpenPopupFormAddPosition = false;
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.getPosition()

          })
          .catch(function () {
            console.log("error");
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    savePosition() {
      this.validateName()
      this.validateNorm()
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.btnAddPosition()
        }
        else {
          this.btnEditPosition()
        }
      }
    },
    OpenPopupFormEditPosition(item) {
      this.isOpenPopupFormEditPosition = true;
      this.suaChucVu = item
      item.ThoiGianBatDau = this.formatDate(item.ThoiGianBatDau)
      this.suaChucVu.ThoiGianBatDau = item.ThoiGianBatDau
      item.ThoiGianKetThuc = this.formatDate(item.ThoiGianKetThuc)
      this.suaChucVu.ThoiGianKetThuc = item.ThoiGianKetThuc
    },
    btnEditPosition() {
      var me = this
      const toast = useToast();
      me.suaChucVu.IDNhanVien = me.IDNV
      try {

        axios
          .put(
            `https://localhost:44301/api/chucvu/${this.suaChucVu.IDBoiDuong}`, this.suaChucVu
          )
          .then(function (res) {
            console.log(res)
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.isOpenPopupFormEditPosition = false;
            me.getPosition()
          })
          .catch(function () {
            console.log("error");
            toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },

    OpenPopupFormAddContract() {
      this.isOpenPopupFormAddContract = true;
      this.suaHopDong = {},
        this.suaHopDong.IDNhanVien = this.IDNV
    },
    btnAddContract() {
      var me = this
      const toast = useToast();
      me.suaHopDong.IDNhanVien = me.IDNV
      console.log(me.suaHopDong);
      try {
        axios
          .post(
            "https://localhost:44301/api/hopdong", this.suaHopDong
          )
          .then(function (res) {
            console.log(res)
            me.isOpenPopupFormAddContract = false;
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.getContract()

          })
          .catch(function () {
            console.log("error");
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    saveContract() {
      this.validateNameHD()
      this.validateNgayKi()
      this.validateNgayBD()
      this.validateNgayKT()
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.btnAddContract()
        }
        else {
          this.btnEditContract()
        }
      }
    },
    OpenPopupFormEditContract(item) {
      this.isOpenPopupFormEditContract = true;
      this.suaHopDong = item
      item.NgayKi = this.formatDate(item.NgayKi)
      this.suaHopDong.NgayKi = item.NgayKi
      item.NgayBD = this.formatDate(item.NgayBD)
      this.suaHopDong.NgayBD = item.NgayBD
      item.NgayKT = this.formatDate(item.NgayKT)
      this.suaHopDong.NgayKT = item.NgayKT
    },
    btnEditContract() {
      var me = this
      const toast = useToast();
      me.suaHopDong.IDNhanVien = me.IDNV
      try {
        axios
          .put(
            `https://localhost:44301/api/hopdong/${this.suaHopDong.IDHopDong}`, this.suaHopDong
          )
          .then(function (res) {
            console.log(res)
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.isOpenPopupFormEditContract = false;
            me.getContract()
          })
          .catch(function () {
            console.log("error");
            toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupFormAddFostering() {
      this.isOpenPopupFormAddFostering = true;
    },
    OpenPopupFormEditFostering() {
      this.isOpenPopupFormEditFostering = true;
    },
    OpenPopupAddNotifi() {
      this.isOpenPopupAddNotifi = true;
    },
    OpenPopupEditNotifi() {
      this.isOpenPopupEditNotifi = true;
    },
    OpenPopupAddNotifiCV() {
      this.isOpenPopupAddNotifiCV = true;
    },
    OpenPopupEditNotifiCV() {
      this.isOpenPopupEditNotifiCV = true;
    },
    OpenPopupDeleteNotifiCV(item) {
      this.idDelete = ""
      this.isShowPopupContract = true
      this.isOpenPopupDeleteNotifiCV = true;
      this.idDelete = item.IDHopDong
      this.mess = "Bạn có chắc chắn muốn xóa thông tin hợp đồng này không?"
    },
    deleteNotifiContract(value) {
      this.isShowPopupContract = value
      var me = this
      const toast = useToast();
      try {
        axios
          .delete(
            `https://localhost:44301/api/hopdong/${this.idDelete}`
          )
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getContract()
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });

          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupDeleteNotifi(item) {
      this.idDelete = ""
      this.isShowPopupPosition = true
      // this.isOpenPopupDeleteNotifi = true;
      this.idDelete = item.IDChucVu
      this.mess = "Bạn có chắc chắn muốn xóa thông tin chức vụ này không?"
    },
    deletePosition(value) {
      this.isShowPopupPosition = value
      var me = this
      const toast = useToast();
      try {
        axios
          .delete(
            `https://localhost:44301/api/chucvu/${this.idDelete}`
          )
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getPosition()
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });

          });
      } catch (error) {
        console.log(error);
      }
    },
    noDelete(value) {
      this.isShowPopupContract = value
      this.isShowPopupPosition = value
    },
    getpagingStudent() {
      try {

        var me = this;
        me.isShowLoad = true
        axios
          .get(
            `https://localhost:44301/api/nhanvien/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&IDKhoa=${this.IDKhoa}&pageNumber=${this.pageNumber}`
          )
          .then(function (res) {
            me.isShowLoad = false
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
    formatDate(date) {
      try {
        if (date) {
          date = new Date(date);
          let newDate = date.getDate();
          let month = date.getMonth() + 1;
          let year = date.getFullYear();
          newDate = newDate < 10 ? `0${newDate}` : newDate;
          month = month < 10 ? `0${month}` : month;
          return `${year}-${month}-${newDate}`;
        }
      } catch (error) {
        return "";
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

    validateName() {
      if (!this.suaChucVu.TenChucVu) {
        this.errors.tenchucvu = "Tên chức vụ Không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.tenchucvu = "";
        this.isValid = true;
      }
    },
    validateNorm() {
      if (!this.suaChucVu.DinhMucGiangDay) {
        this.errors.dinhmucgiangday = "Định mức giảng dạy không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.dinhmucgiangday = "";
        this.isValid = true;
      }
    },
    validateNameHD() {
      if (!this.suaHopDong.TenHD) {
        this.errors.tenhopdong = "Tên hợp đồng không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.tenhopdong = "";
        this.isValid = true;
      }
    },
    validateNgayKi() {
      if (!this.suaHopDong.NgayKi) {
        this.errors.ngayki = "Ngày kí không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.ngayki = "";
        this.isValid = true;
      }
    },
    validateNgayBD() {
      if (!this.suaHopDong.NgayBD) {
        this.errors.ngaybatdau = "Ngày bắt đầu không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.ngaybatdau = "";
        this.isValid = true;
      }
    },
    validateNgayKT() {
      if (!this.suaHopDong.NgayKT) {
        this.errors.ngayketthuc = "Ngày kết thúc không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.ngayketthuc = "";
        this.isValid = true;
      }
    },
  },

  // 

};
</script>
<style scoped>
.invalid-feedback {
  color: red;
  position: absolute;
  font-size: 12px;
  margin-top: -14px;
  /* border: 2px solid red; */
}


.btnCancel {
  color: #5d82e0;
  position: absolute;
  right: 150px;
  border: 1px solid #5d82e0;
  bottom: 20px;
  padding: 4px;
  min-width: 67px;
  border-radius: 5px;

  text-align: center;
}

.btnCancel:hover {
  background-color: #5d82e0;
  color: #fff;
}

.btnSave {
  width: 67px;
  border: 1px solid;
  text-align: center;
  padding: 5px;
  border-radius: 5px;
  color: #fff;
  background-color: #5d82e0;
  position: absolute;
  right: 40px;
  bottom: 20px;
}

.btnSave:hover {
  border: 1px solid #7EA1F9;
  color: #7EA1F9;
  background-color: #fff;
}

.column input {
  width: 80%;
}

.input__box {
  display: block;
}

.title-heading {
  text-align: center;
  width: 100%;
  font-size: 18px;
}

.education-header {
  font-weight: 600;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 20px 0;
}

.btnWrap {
  display: flex;
  column-gap: 10px;
}

.btnAdd,
.btnEdit {
  padding: 3px 25px;
  background: #7EA1F9;
  border-radius: 5px;
  color: #fff;
  border: 1px solid #7EA1F9;
}

.btnAdd:hover,
.btnEdit:hover {
  border: 1px solid #7EA1F9;
  background-color: #fff;
  color: #000;
}

.btnDelete {
  padding: 3px 25px;
  border-radius: 5px;
  color: #fff;
  background-color: red;
  right: 40px;
  position: absolute;
  bottom: 15px;
}

.btnDelete:hover {
  border: 1px solid red;
  background-color: #fff;
  color: #000;
}

ul.pagination {
  display: flex;
  color: #111;
  list-style-type: none;
}

th {
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
  text-align: left;
  padding: 0px 10px;
  height: 35px;
  box-sizing: border-box;
}

td {
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
  padding: 0px 10px;
  text-align: left;
  height: 44px;
  box-sizing: border-box;
}

ul.pagination a {
  text-decoration: none;
  color: #111;
  width: 200px;
}

.content-page {
  min-width: 170px;
  margin-left: 6px;
  margin-right: 10px;
  margin-top: 9px;
  position: relative;
}

.page-link {
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

.page {
  margin-top: 10px;
  margin-right: 20px;
}

table {
  width: 90%;
}

table,
tr {
  border: none;
  padding: 0px 5px 5px 5px;
  background-color: white;
  margin-top: 0px;
}

td {
  border: none;
  background-color: white;
  margin-top: 0px;
}

tbody tr td {
  color: #111;
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
}

.width-half {
  width: 50%;
}

.color-red {
  color: red;
}

.border-red {
  border-color: red;
}

.btn-action:hover {
  background: #74bbd4;
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
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgb(17 17 17 / 16%);
  z-index: 2;
  cursor: pointer;
}

/* .form {
  left: -90px;
  top: 82px;
  width: 87%;
} */

.bonus-form {
  padding: 0px 20px;
  position: absolute;
  width: 50vw;
  height: 590px;
  /* height: auto; */
  margin: 0 auto;
  top: 12%;
  right: 24%;
  z-index: 99999;
  border-radius: 20px;
  box-shadow: 5px 5px 5px;
  background-color: #fff;
}

.bonus-formm {
  padding: 0px 20px;
  position: absolute;
  width: 42vw;
  height: 590px;
  /* height: auto; */
  margin: 0 auto;
  top: 12%;
  right: 28%;
  z-index: 99999;
  border-radius: 20px;
  box-shadow: 5px 5px 5px;
  background-color: #fff;
}

.head-popup {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: white;
  margin-bottom: 0 !important;
  margin-top: 10px;
  width: 96%;
  margin-left: 4px;
}

svg:hover {
  color: red;
}

.btn-close-popup:hover {
  color: red !important;
}

input {
  width: 300px;
}

table[data-v-07d000ee],
tr[data-v-07d000ee],
td[data-v-07d000ee] {
  border: none;
  padding: 0px 0px 5px 5px;
  margin-bottom: 5px;
  margin-top: 0px;
  margin-left: 4px;

}

.sticky-right-top {
  position: sticky;
  z-index: 0;
  right: 0;
  top: 0;
  background-color: #e5e8ec;
}

.sticky-left-top {
  position: sticky;
  z-index: 0;
  left: 0;
  top: 0;
  background-color: #e5e8ec;
}

thead tr {
  background-color: #e5e8ec;
}

.desc {
  color: red;
  cursor: pointer;
  font-weight: 600;
}

.desc:hover {
  text-decoration: underline;
}

tbody tr:hover .checkbox,
tbody tr:hover .td-item-final {
  background-color: #fff !important;
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

.form input {
  width: 100%;
  margin-top: 5px;
  margin-bottom: 15px;
}

.form {
  position: absolute;
  width: 88%;
  height: fit-content;
  background-color: #fff;
  margin: auto auto;
  border-radius: 8px;
}

.formm {
  width: 100%;
  height: fit-content;
  background-color: #fff;
  margin: auto auto;
  border-radius: 8px;
}
</style>
  