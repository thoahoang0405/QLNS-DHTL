<template>
  <div class="body">
    <h3 class="header-bd">Quản lý tuyển dụng</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" placeholder="Tìm kiếm " />
          <div class="icon-search icon"></div>
        </div>
      </div>
      <div class="button-function">
        <div class="add">
          <button class="btn-add btn-hover-blue">+ Thêm tin tuyển dụng</button>
        </div>

        <!-- <button class="btn-excel">
          <div class="icon icon-excel">
            <div class="tooltip-excel">Xuất ra excel</div>
          </div>
        </button> -->
      </div>
    </div>
    <div id="body-recruit">
      <div class="body-recruit">
     
      <div class="item-row">
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh7.png" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Hệ quản trị CSDL</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Đại học</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh2.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Đồ họa máy tính</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh5.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Toán 1</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Đại học</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh1.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Kiến trúc máy tính</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Đại học</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh3.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Trí tuệ nhân tạo</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh8.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Lập trình Web</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>

            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh9.jpeg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Cở sở dữ liệu</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
        </div>
        <div class="item-recruit">
          <div class="body-rec">
            <div>
              <img class="image" src="../../assets/img/anh10.jpg" alt="" />
            </div>
            <div class="title-wrap">
              <h3 class="header-h3">Xử lý ảnh</h3>
              <!-- <div class="title-name">Đại học thủy lợi</div> -->
              <div>Văn bằng: Thạc sĩ</div>
              <div class="btn-wrap">
                <div class="btnEdit">Edit</div>
                <div class="btnDelete">Delete</div>
              </div>
            </div>
          </div>
        </div>

      </div>
     </div>
    </div>
  </div>
 
</template>
<style scoped>
.body-header {
 height: 60px;
 box-sizing: border-box;
}
#body-recruit {
  margin: 0 auto;
  width: 100%;
 height: calc(100% - 120px);
 background-color: #e7e7e7;
}
.body-recruit{
  height: 100%;
  width: 100%;
  overflow-y: scroll;
}
.title-wrap {
  /* margin-top: 40px; */
}
.item-row{
  display: flex;
  align-items: center;
  flex-wrap: wrap;
  justify-content: center;
}
/* .item-row {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
  /* justify-content: space-between; */
  /* flex-wrap: wrap; */


.item-recruit {
  border-radius: 4px;
  width: 276px;
  background-color: #fff;
  padding: 8px;
  margin: 8px 8px;
  /* height: 310px; */
  /* overflow-y: hidden; */
}
.image {
  border-radius: 4px;
  width: 100%;
  height: 100%;
}
.title-name {
  margin-bottom: 10px;
}
.btn-wrap {
  display: flex;
  justify-content: flex-end;
  column-gap: 10px;
  margin-top: 10px;
} 
.btnEdit,
.btnDelete {
  border: 1px solid #ccc;
  padding: 6px 8px;
  border-radius: 2px;
  cursor: pointer;
}

/* @media screen and (max-width: 767.98px) {
  .item-row{
    display: grid;
    grid-template-columns: repeat(2,1fr);
}
}
@media screen and (max-width: 600px) {
  .item-row{
    display: grid;
    grid-template-columns: 1fr;
}
} */
</style>

<script>
// import FomrD from '../base/FormDetail.vue';
export default {
  components: {},
  data() {
    return {
      isShow: false,
    };
  },
};
</script>
