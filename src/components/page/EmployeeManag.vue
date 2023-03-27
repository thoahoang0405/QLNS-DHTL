<template>
  <div class="body">
    <!-- so yeu ly lich -->
    <!-- <div class="popup-bonus" v-if="isOpenPopupCurriculumVitae">
        <div class="bonus-form">
          <div class="head-popup">
            <h2 class="title-heading">Sơ yếu lý lịch</h2>
            <div class="btn-close-popup" @click.stop="isOpenPopupCurriculumVitae = false">
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
          <div>
          <div class="education-header">
              <div class="maNV">Mã nhân viên:  {{ MaNV }}</div>
              <div class="tenNV">Tên nhân viên:  {{ TenNV }}</div>
              <div class="btnWrap">
                <div class="btnEdit" @click="OpenPopupFormEditCurriculumVitae(item)">Sửa lý lịch</div>
                <div class="btnEdit">Sửa</div> -->
              <!-- </div>
          </div> -->
      <!-- <form class="formm" v-for="item of nhanvien" :key="item.IDNhanVien">
        <div class="form-Wrap">
          <div class="column">
            <div class="input__boxx">
              <label for="">Ngày sinh </label>
              <input 
                class="ngaysinh"
                type="date"
              />
            </div>
            <div class="input__boxx">
              <label for="">Giới tính</label>
              <div class="radio__box">
                <input 
                  type="radio"
                  id="nam"
                  value="0"
                />
                <label class="nam" for="">Nam</label>
                <input
                  type="radio"
                  id="nu"
                  value="1"
                />
                <label class="nu" for="">Nữ</label>
              </div>
            </div>
          </div>

          <div class="column">
            <div class="input__boxx">
              <label for="">Số điện thoại</label>
              <input class="sodt" type="text"/>
            </div>
            <div class="input__boxx">
              <label for="">Email</label>
              <input class="email" type="text" />
            </div>
          </div>

          <div class="column">
            <div class="input__boxx">
              <label for="">Địa chỉ</label>
              <input class="diachi" type="text"/>
            </div>
            <div class="input__boxx">
              <label for="">Dân tộc</label>
              <input class="dantoc" type="text"/>
            </div>
            <div class="input__boxx">
              <label for="">Tôn giáo</label>
              <input class="tongiao" type="text"/>
            </div>
          </div>
          <div class="column">
            <div class="input__boxx">
              <label for="">CCCD</label>
              <input class="cccd" type="text"/>
            </div>
            <div class="input__boxx">
              <label for="">Ngày cấp</label>
              <input class="ngaycap" type="date"/>
            </div>
            <div class="input__boxx">
              <label for="">Nơi cấp</label>
              <input class="noicap" type="text"/>
            </div>
          </div>
          <div class="column">
            <div class="input__boxx">
              <label for="">Mã khoa</label>
              <input class="makhoa" type="text"/>
            </div>
            <div class="input__boxx">
              <label for="">Tên khoa</label>
              <input class="tenkhoa" type="text"/>
            </div>
          </div>
        
        </div>
        
      </form> -->
    <!-- <notifi
      v-show="isShowNotifi"
      @closeNotifi="closeNo"
      @cancelNotifi="FormCancel"
    ></notifi> -->
    <!-- <popUpDup @closeNotifi="closePoup" v-show="isShowPop"></popUpDup> -->
    
  <!-- </div>
        </div>
    </div> -->
    <!-- sua ly lich -->
    <div class="popup-bonus" v-if="isOpenPopupFormEditCurriculumVitae">
        <div class="bonus-form">
          <div class="head-popup">
            <h2 class="title-heading">Sửa sơ yếu lý lịch</h2>
            <div class="btn-close-popup" @click.stop="isOpenPopupEditNotifiCV = true">
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
          <div class="education-header">
              <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
              <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
              <div class="btnWrap">
              </div>
          </div>
          <form class="formm">
            <div class="form-Wrap">
              <div class="column">
                <div class="input__boxx">
                  <label for="">Ngày sinh </label>
                  <input
                    class="ngaysinh"
                    type="date"
                  />
                </div>
                <div class="input__boxx">
                  <label for="">Giới tính</label>
                  <div class="radio__box">
                    <input
                      type="radio"
                      id="nam"
                      value="0"
                    />
                    <label class="nam" for="">Nam</label>
                    <input
                      type="radio"
                      id="nu"
                      value="1"
                    />
                    <label class="nu" for="">Nữ</label>
                  </div>
                </div>
              </div>

              <div class="column">
                <div class="input__boxx">
                  <label for="">Số điện thoại</label>
                  <input class="sodt" type="text"/>
                </div>
                <div class="input__boxx">
                  <label for="">Email</label>
                  <input class="email" type="text" />
                </div>
              </div>

              <div class="column">
                <div class="input__boxx">
                  <label for="">Địa chỉ</label>
                  <input class="diachi" type="text"/>
                </div>
                <div class="input__boxx">
                  <label for="">Dân tộc</label>
                  <input class="dantoc" type="text"/>
                </div>
                <div class="input__boxx">
                  <label for="">Tôn giáo</label>
                  <input class="tongiao" type="text"/>
                </div>
              </div>
              <div class="column">
                <div class="input__boxx">
                  <label for="">CCCD</label>
                  <input class="cccd" type="text"/>
                </div>
                <div class="input__boxx">
                  <label for="">Ngày cấp</label>
                  <input class="ngaycap" type="date"/>
                </div>
                <div class="input__boxx">
                  <label for="">Nơi cấp</label>
                  <input class="noicap" type="text"/>
                </div>
              </div>
              <div class="column">
                <div class="input__boxx">
                  <label for="">Mã khoa</label>
                  <input class="makhoa" type="text"/>
                </div>
                <div class="input__boxx">
                  <label for="">Tên khoa</label>
                  <input class="tenkhoa" type="text"/>
                </div>
              </div>
            
            </div>
          </form>
          <div class="btnCancel" @click.stop="isOpenPopupEditNotifiCV = true">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
    </div>
    <!-- Cảnh báo thêm lý lịch-->
    <!-- <div class="notification-wrap" v-if="isOpenPopupAddNotifiCV">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupAddNotifi = false, isOpenPopupAddState=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifi = false">Không</div>
          </div>
      </div>
      </div> -->
    <!-- cảnh báo sửa lý lịch-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifiCV">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupEditNotifiCV = false, isOpenPopupFormEditCurriculumVitae=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupEditNotifiCV = false">Không</div>
          </div>
      </div>
    </div>
    <!--  -->
    <!-- trang thai -->
    <div class="popup-bonus" v-if="isOpenPopupState">
        <div class="bonus-form">
          <div class="head-popup">
            <h2 class="title-heading">Trạng thái</h2>
            <div class="btn-close-popup" @click.stop="isOpenPopupState = false">
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
          <div class="education-header">
            <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
            <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
            <div class="btnWrap">
              <div class="btnAdd" @click="OpenPopupAddState(item)">Thêm</div>
              <div class="btnEdit" @click="OpenPopupEditState(item)">Sửa</div>
            </div>
          </div>
          <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <thead>
              <tr>
                <th colspan="2">Quan hệ gia đình</th>
                <th colspan="3">Trạng thái</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <th>Tình trạng</th>
                <th>Gia đình</th>
                <th>Tên tình trạng</th>
                <th>Ngày bắt đầu</th>
                <th>Ngày kết thúc</th>
              </tr>
            </tbody>
            <!-- <th style="width: 60px;">Chức năng</th> -->
            <tr>
            </tr>
            <tr v-for="emp of tinhtrang" :key="emp.IDTinhTrang">
              <td style="border: 1px solid #c7c7c7; width: 150px;"></td>
              <td style="border: 1px solid #c7c7c7; width: 250px;"></td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ emp.TenTinhTrang }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ emp.NgayBD }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ emp.NgayKT }}</td>
              
              <!-- <td 
              ref="func"
              class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7;"
              colspan="12"
              >
                <div class="icon icon-edit" @click="OpenPopupAddState(item)"></div>
                <div class="icon icon-delete"></div>
              </td> -->
            </tr>
          </table>
        </div>
      </div>
      <!-- them trang thai -->
      <div class="popup-bonus" v-if="isOpenPopupAddState">
        <div class="bonus-form">
          <div class="head-popup">
            <h2 class="title-heading">Thêm trạng thái</h2>
            <div class="btn-close-popup" @click.stop="isOpenPopupAddNotifi = true">
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
          
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
            <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          </div>
          <div class="column">
            <div class="input__state">
              <label for="">Tình trạng: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__state">
              <label for="">Gia đình: </label>
              <textarea style="width: 80%;height: 60px;" type="text"> </textarea>
           </div>
          </div> 
          <div class="column">
            <div class="input__state">
              <label for="">Tên tình trạng: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__state">
              <label for="">Ngày bắt đầu: </label>
              <input type="date">
            </div>
          </div>
          <div class="column">
            <div class="input__state">
              <label for="">Ngày kết thúc: </label>
              <input type="date">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupAddNotifi = true">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- sua trang thai -->
      <div class="popup-bonus" v-if="isOpenPopupEditState">
        <div class="bonus-form">
          <div class="head-popup">
            <h2 class="title-heading">Sửa trạng thái</h2>
            <div class="btn-close-popup" @click.stop="isOpenPopupEditNotifi = true">
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
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
            <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          </div>
          <div class="column">
            <div class="input__state">
              <label for="">Tình trạng: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__state">
              <label for="">Gia đình: </label>
              <textarea style="width: 80%;height: 60px;" type="text"> </textarea>
           </div>
          </div> 
          <div class="column">
            <div class="input__state">
              <label for="">Tên tình trạng: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__state">
              <label for="">Ngày bắt đầu: </label>
              <input type="date">
            </div>
          </div>
          <div class="column">
            <div class="input__state">
              <label for="">Ngày kết thúc: </label>
              <input type="date">
            </div>
          </div>
          <!-- <div class="btnCancel" @click.stop="isOpenPopupEditNotifi = true">Hủy</div> -->
          <div class="btnCancel" @click.stop="isOpenPopupEditNotifi = true">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- Cảnh báo thêm trạng thái-->
      <div class="notification-wrap" v-if="isOpenPopupAddNotifi">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupAddNotifi = false, isOpenPopupAddState=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifi = false">Không</div>
          </div>
      </div>
      </div>
    <!-- cảnh báo sửa trạng thái-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifi">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupEditNotifi = false, isOpenPopupEditState=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupEditNotifi = false">Không</div>
          </div>
      </div>
    </div>
    <!--  -->
    <h3 class="header-bd">Quản lý nhân viên</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search"   v-model="txtSearch"  @keypress.enter="getPagingEmployee"  placeholder="Tìm kiếm sinh viên" />
          <div class="icon-search icon"></div>
        </div>
        
        <Combobox
          :items="department"
         
          :fieldName="'TenKhoa'"
         
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

        <button @click="getPagingEmployee" class="btn-excel">
          <div class="icon icon-load">
            <div class="tooltip-excel">Lấy lại dữ liệu</div>
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
              <th>Ngày sinh</th>
              <th>Giới tính</th>
              <th>Tôn giáo</th>
              <th>Dân tộc</th>
              <th>CCCD</th>
              <th>Ngày Cấp</th>
              <th>Nơi Cấp</th>
              <th>Email </th>
              <th>Địa chỉ</th>
              <th>SĐT</th>
              <th>Tên Khoa</th>
              <!-- <th>Sơ yếu lý lịch</th> -->
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
        <tbody >
          <tr ref="row" v-for="(emp, index) of employees" :key="emp.IDNhanVien">
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
            <td>{{ emp.MaNV }}</td>
            <td>{{ emp.TenNV }}</td>
            <td>{{ emp.NgaySinh }}</td>
            <td>{{ emp.GioiTinh }}</td>
            <td>{{  emp.TonGiao }}</td>
            <td>{{  emp.DanToc }}</td>
            <td>{{  emp.CCCD }}</td>
            <td>{{  emp.NgayCap }}</td>
            <td>{{  emp.NoiCap }}</td>
            <td>{{ emp.Email }}</td>
            <td>{{ emp.DiaChi }}</td>
            <td>{{ emp.SDT }}</td>
            <td>{{ emp.TenKhoa }}</td>
            <!-- <td>
                <div class="desc" @click="OpenPopupCurriculumVitae(emp)">
                  Xem chi tiết
                </div>
            </td> -->
            <td>
                <div class="desc" @click="OpenPopupState(emp)">
                  Xem chi tiết
                </div>
            </td>
            <td
              ref="func"
              class="td-item-final td-func sticky-right; align-items: center;"
              style="position: sticky; right: 0; background-color: #fff"
              colspan="12"
            >
              <div class="edit-text"></div> 
              <div class="icon icon-edit" @click="OpenPopupFormEditCurriculumVitae(emp)" ></div>
              <div class="icon icon-delete" @click="deleteEmployee(emp)"></div>
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
  <popUp v-show="isShowPopup" :msv="empCodeDelete" @closeNotifi="deleteEmp"></popUp>
<Form v-show="isShow" @hideForm="closeForm" :loadData="getPagingEmployee" :employeeId="IDNhanVien"  :FormMode="formMode" :employeeSL="employeeSelect" :code="newCode"></Form>
<!-- <div id="load" ></div> -->
</template>
<style>
@import url('../../css/page/loading.css');
  .btn-add:hover {
    opacity: 0.8;
  }
  .border-red {
  border: 1px solid red;
  }
  .desc {
  color: red;
  cursor: pointer;
  font-weight: 600;
}
.desc:hover {
  text-decoration: underline;
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
  .bonus-form {
    left: 50%;
    transform: translate(-50%,-5%);
    padding: 0px 20px;
    position: absolute;
    width: 55vw;
    height: 550px;
    /* height: auto; */
    margin: 0 auto;
    top: 15%;
    right: 15%;
    z-index: 99999;
    border-radius: 20px;
    box-shadow: 5px 5px 5px ;
    background-color: #fff;
  }
  .head-popup {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: white;
    margin-bottom: 0 !important;
    margin-top: 10px;
    /* width: 96%; */
  }
  svg:hover {
    color: red;
  }
  .btn-close-popup::hover {
    color: red !important;
  }
  .form {
  background-color: rgba(0, 0, 0, 0.2);
  z-index: 3;
  width: 100%;
  height: 100%;
  margin: auto;
  position: fixed;
  display: flex;
  /* display: none; */
  }
.formm input {
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
  margin-bottom: 7px;
}
.form {
  flex-direction: column;
  width: fit-content;
  height: fit-content;
  background-color: #fff;
  margin: auto auto;
  border-radius: 8px;
  width: 800px;
  margin-top: 100px;
  margin-left: 370px;
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
.column {
  margin-bottom: 12px;
}
.column input {
    /* width: 80%; */
  }
.input__box {
  display: flex;
  justify-content: space-between;
  width: 100%;
  margin-bottom: 10px;
}
.form-bottom {
  display: flex;
  justify-content: flex-end;
  padding: 8px;
  gap: 28px;
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
.education-header {
  margin-bottom: 20px;
  font-weight: 600;
  display: flex;
  justify-content: space-between;
  align-items: center;
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
  .btnCancel,
  .btnSave {
    width: 85px;
    border: 1px solid;
    text-align: center;
    padding: 5px;
    border-radius: 5px;
    color: #fff;
    
  }
  .btnSave {
    background-color: #7EA1F9;
    position: absolute;
    right: 40px;
    bottom: 20px;
  }
  .btnCancel {
    color: #000;
    border: 1px solid #ccc;
    position: absolute;
    right: 150px;
    bottom: 20px;
  }
  .btnCancel:hover {
    background-color: red;
    color: #fff;
  }
  .btnSave:hover {
    border: 1px solid #7EA1F9;
    color: #000;
    background-color: #fff;
  }
  .input__box {
    display: block;
  }
  .input__boxx {
    display: block;
    width: 100%;
  }
  .input__state{
    margin-bottom: 14px;
    display: flex;
    justify-content: space-between;
    width: 100%;
  }
  .input__state input {
    width: 80%;
  }
  .notification-wrap {
    background-color: rgba(0, 0, 0, 0.2);
    z-index: 4;
    width: 100%;
    height: 100%;
    margin: auto;
    position: fixed;
    display: flex;
  
    }
    .notification{
        z-index: 3;
        position: absolute;
        left: 50%;
        top: 50%;
        transform: translate(-90%,-80%);
        background-color: #fff;
        width: 420px;
        height: 150px;
        padding: 20px;
        border-radius: 2px;
        box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
    }
    .warring{
        display: flex;
        justify-content: center;
        align-items: center;
        margin-top: 30px;
    }
    .warring i {
        font-size: 60px;
        width: 52px;
        height: 40px;
        color: #F4A733;
    }
    .warrning-title{
        text-align: center;
        font-size: 16px;
        margin-left: 8px;
    }
    .btn-wrap {
        display: flex;
        justify-content: flex-end;
        align-items: center;
        column-gap: 20px;
    }
    .btnNotifi{   
        display: flex;
        width: 100px;
        align-items: center;
        justify-content: center;
        margin-top: 38px;
        border-radius: 2px;
        height: 25px;
        cursor: pointer;
    }
    .btnNotifi:hover {
        opacity: 0.8;
        color: red;
    }
    .btn-secondary{
        border: 1px solid #1A8FDD;
    }
    .btn-primary{
        margin-right: 40px;
        background-color: #1A8FDD;
        color: #fff;
    }
    @media screen and (max-width: 767.98px) {
        .notification{
            font-size: 15px;
            width: 300px;
            height: 130px;
            padding: 14px;
        }
        .warring {
            margin-top: 6px;
        }
        .warring i {
            font-size: 50px;
        }
        .btnNotifi {
            width: 80px;
            margin-top: 20px;
        }
    }
</style>
<script>
import Paginate from "vuejs-paginate-next";
import axios from "axios";
import Form from "../base/FormEmployee.vue"
import $ from "jquery";
import Combobox from "../base/BaseCombobox2.vue";
import popUp from "../base/BasePopupDelete.vue"
import { useToast } from "vue-toastification";

export default {
  components: {
    Paginate,Form,Combobox,popUp
  },
  data() {
    return {
      isOpenPopupCurriculumVitae: false,
      isOpenPopupFormEditCurriculumVitae: false,
      isOpenPopupState: false,
      isOpenPopupAddState: false,
      isOpenPopupEditState: false,
      isOpenPopupEditNotifi: false,
      isOpenPopupAddNotifi: false,
      isOpenPopupAddNotifiCV: false,
      isOpenPopupEditNotifiCV: false,
      isActive: "20",
      pageNumber: 1,
      page: 1,
      employees:{},
      totalPage: 1,
      isShow: false,
      isShowDrop: false,
      totalRecord: 0,
      IDKhoa:"",
      pageDefault: 20,
      department:{},
      isShowLoad:false,
      position:{},
      departmentID:"",
      positionID:"",
      txtSearch:" ",
      employeeSelect:{},
      newCode: "",
      formMode: 1,
      IDNhanVien:"",
      isShowPopup:false,
      empCodeDelete:"",
      empID:"",
      MaNV:"",
      TenNV:"",
      nhanvien: {},
      suanhanvien: {},
      tinhtrang: {},
      IDNV:"",
    };
  },
  created() {
    this.getPagingEmployee()
    // this.getDepartment()
    // this.getPosition()
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getPagingEmployee();
      }
    },
  },
  methods: {
    OpenPopupCurriculumVitae(emp) {
        this.isOpenPopupCurriculumVitae = true;
        this.dataSinhVienPunish = emp
        this.IDNV = emp.IDNhanVien
        this.MaNV = emp.MaNV
        this.TenNV = emp.TenNV
        try {
       
       var me = this;
       
       axios
         .get(
             `https://localhost:44301/api/nhanvien/${this.IDNV}`
         )
         .then(function (res) {
         me.tinhtrang=res.data
         })
         
         .catch(function () {
           console.log(1);
         });
        } catch (error) {
          console.log(error);
        }
    },
    OpenPopupFormEditCurriculumVitae(emp) {
      this.isOpenPopupFormEditCurriculumVitae = true;
      this.dataSinhVienPunish = emp;
      this.IDNV = emp.IDNhanVien
        this.MaNV = emp.MaNV
        this.TenNV = emp.TenNV
        try {
       
          var me = this;
          
          axios
            .get(
                `https://localhost:44301/api/nhanvien/${this.IDNV}`
            )
            .then(function (res) {
            me.hocvan=res.data
            })
            
            .catch(function () {
              console.log(1);
            });
        } catch (error) {
          console.log(error);
        }
    },
    OpenPopupState(emp) {
        this.isOpenPopupState = true;
        this.dataSinhVienPunish = emp
        this.IDNV = emp.IDNhanVien
        this.MaNV = emp.MaNV
        this.TenNV = emp.TenNV
        try {
       
       var me = this;
       
       axios
         .get(
             `https://localhost:44301/api/tinhtrang/${this.IDNV}`
         )
         .then(function (res) {
         me.tinhtrang=res.data
         })
         
         .catch(function () {
           console.log(1);
         });
        } catch (error) {
          console.log(error);
        }
    },
    OpenPopupAddState(item) {
        this.isOpenPopupAddState = true;
        this.dataSinhVienPunish = item
    },
    OpenPopupEditState(item) {
      this.isOpenPopupEditState = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupAddNotifi(item) {
      this.isOpenPopupAddNotifi = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupEditNotifi(item) {
      this.isOpenPopupEditNotifi = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupAddNotifiCV(item) {
      this.isOpenPopupAddNotifiCV = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupEditNotifiCV(item) {
      this.isOpenPopupEditNotifiCV = true;
      this.dataSinhVienPunish = item
    },
    deleteEmployee(emp){
      this.isShowPopup=!this.isShow
      this.empCodeDelete= emp.IDNhanVien
      this.empID=emp.IDNhanVien
    },
    deleteEmp(value){
      this.isShowPopup=value
      var me = this;
      const toast = useToast();
      try{
       axios
         .delete(
          `https://localhost:44301/api/nhanvien/${me.empID}`
         )
         .then(function (res) {
          console.log(res);
          toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
          me.getPagingEmployee()
         })
        
         .catch(function () {
          toast.error("xóa dữ liệu thất bại", { timeout: 2000 });
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }
    },
    editEmployee(emp){
      this.employeeSelect=emp
      this.IDNhanVien=emp.IDNhanVien
     this.isShow=true
     this.formMode=2
    },
    getPagingEmployee() {
      try {
        var me = this;
       me.isShowLoad=true
        axios
          .get(
            `https://localhost:44301/api/nhanvien/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&IDKhoa=${this.IDKhoa}&pageNumber=${this.pageNumber}`
           
          )
          .then(function (res) {
          console.log(res);
            me.totalPage = res.data.TotalPages;
            me.totalRecord = res.data.TotalRecords;
            me.employees = res.data.Data;
            console.log( me.totalPage);
            console.log(me.employees);
            me.isShowLoad=false
            
          })
         
          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    
    // getPosition(){
    //   try {
       
    //    var me = this;
      
    //    axios
    //      .get(
    //       "https://localhost:44301/api/Position"
    //      )
    //      .then(function (res) {
    //       me.position=res.data
    //      })
        
    //      .catch(function () {
    //        console.log(1);
    //      });
    //  } catch (error) {
    //    console.log(error);
    //  }

    // },
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
    // selectItemCbb(value) {
    
    //   if (value.IDKhoa) {
    //     this.IDKhoa = value.IDKhoa;
    //   } else {
    //     this.IDKhoa = "";
    //     this.getPagingEmployee();
    //   }
    //   this.getPagingEmployee();
     
    // },
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
      this.employeeSelect={}
      this.getNewCode()
      this.formMode=1;
      this.isShow = !this.isShow
    },
    
    getNewCode(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api​/nhanvien​/NewCode"
         )
         .then(function (res) {
          me.newCode=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }
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
