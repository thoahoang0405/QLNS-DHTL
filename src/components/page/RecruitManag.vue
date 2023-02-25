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
    <div class="body-recruit">
        <div class="item-row">
            <div class="item-recruit">
                <h3 class="header-rec">Giảng viên môn Web</h3>
                <div class="body-rec">
                    <div>Đại học thủy lợi</div>
                    <div>cấp bậc 2</div>
                    <div> 2 năm kinh nghiệm</div>
                </div>
            </div>
            <div class="item-recruit"></div>
            <div class="item-recruit"></div>
        </div>
    </div>
    </div>
   
</template>
<style scoped>
.item-row{
    display: flex;
    justify-content: space-between;
}
.item-recruit{
    width: 350px;
    height: 200px;
    background-color: #fff;
    padding: 8px;
}
</style>