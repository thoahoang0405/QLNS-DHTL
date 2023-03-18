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
            <input type="text" class="search" placeholder="Tìm kiếm" />
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
              <th class="text-center" style="min-width: 40px">STT</th>
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
            <tr v-for="i in 5" :key="i" ref="row">
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
                <div class="icon"  @click="OpenPopupPunish()">
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
                      d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10"
                    />
                  </svg>
                </div>
                <div class="icon" @click="OpenPopupBonus()">
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
                      d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L6.832 19.82a4.5 4.5 0 01-1.897 1.13l-2.685.8.8-2.685a4.5 4.5 0 011.13-1.897L16.863 4.487zm0 0L19.5 7.125"
                    />
                  </svg>
                </div>
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
  <script>
  export default {
    data() {
      return {
        isOpenPopupBonus: false,
        isOpenPopupPunish: false
      };
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
    },
  };
  </script>
  <style scoped>
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
  .head-popup {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: white;
    margin-bottom: 0 !important;
  }
  svg::hover {
    color: red;
  }
  .btn-close-popup::hover {
    color: red !important;
  }
  </style>
  