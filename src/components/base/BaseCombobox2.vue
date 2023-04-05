<template>
  <div class="m-combobox m-combobox-2" @click="toggleCombobox" @keyup.enter="selectItem" @keyup.down.stop="keyDown"
    @keyup.up.stop="keyUp">
    <input class="input" v-model="keyword" :placeholder="this.placeholder" :tabindex="tab" :class="border" @blur="onBlur"
      @keydown="keyTab" :ref="refName" />
    <div class="icon-filter icon"></div>
    <div class="up-down">
      <div class="down">
        <div class="icon-down-bold"></div>
      </div>
    </div>

    <div class="drop-down" v-show="isShowCbb">


      <div class="drop-down-body">
        <div v-for="(item, index) of dataItems" class="drop-down-item"
          :class="item[fieldName] == currentItem[fieldName] ? 'active' : ''" @click.exact.stop="onClickItem(item)"
          :key="item">
          <div class="icon-tick">
            <div :id="index" v-show="item[fieldName] == currentItem[fieldName]" class=" tick"></div>
          </div>
          <div class="drop-down-name">{{ item[fieldName] }}</div>
        </div>
      </div>
    </div>
  </div>
</template>
  <!-- :class="item[fieldCode] == currentItem[fieldCode] ? 'active' : ''" -->
<script>

export default {
  props: {
    label: {
      type: String,
    },
    items: {
      type: Array,
    },
    fieldName: {
      type: String,
    },
    fieldCode: {
      type: String,
    },
    code: {
      type: String,
    },
    tab: {
      type: String,
    },
    border: {
      type: String,
    },
    refName: {
      type: String,
    },
    value: {
      type: String,
    },
    Filter: {
      type: Int16Array,
    },

  },
  data() {
    return {
      currentItem: {}, // item hiện tại
      isShowCbb: false, // show drop-down
      placeholder: "Nhập giá trị ", // playholder
      dataItems: [],
      keyword: "",
      i: -1,
      hOfItem: 35,
      hOfBody: 135,
      filter: 0,
    };
  },

  methods: {
    /**
     * hàm xử lý sự kiện khi blur
     *
     */
    onBlur() {
      setTimeout(() => {
        this.isShowCbb = false;
      }, 200);
      this.$emit("keyword", this.keyword)
      console.log(this.keyword);
      this.$emit("onBlur");

    },
    /**
     * hàm chọn item khi nhấn enter
     *
     */
    keyTab() {
      var code = event.keyCode || event.which;
      if (code === 9) {
        this.onFocus();
      }
    },
    selectItem() {
      this.$emit("selectedItem", this.currentItem);
      console.log(this.currentItem);
      this.keyword = this.currentItem[this.fieldName];

      this.isShowCbb = false;
      this.i = 0;
      this.$el.querySelector(".input").focus();
      this.dataItems = this.items;
    },
    /**
     * hàm click chọn item
     *
     */
    onClickItem(item) {
      this.currentItem = item;
      this.selectItem();
    },

    toggleCombobox() {
      this.isShowCbb = !this.isShowCbb;
      if (this.isShowCbb == true) {
        this.scrollItem((this.i - 1) * this.hOfItem);
      }
    },

    scrollItem(position) {
      if (position >= 0) {
        this.$el.querySelector(".drop-down-body").scrollTo(0, position); //cuộn đến tọa độ (0,position)
      }
    },
    keyDown() {
      try {
        if (!this.isShowCbb) {
          this.isShowCbb = true;
        } else {
          this.i++;
          if (this.i > this.dataItems.length - 1) {
            this.i = this.dataItems.length - 1;
          }
          this.currentItem = this.dataItems[this.i];
          this.scrollItem((this.i - 1) * this.hOfItem);
        }
      } catch (error) {
        console.log(error);
      }
    },
    keyUp() {
      try {
        if (this.i > 0) {
          this.i--;
          this.currentItem = this.dataItems[this.i];
          this.scrollItem((this.i - 1) * this.hOfItem);
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * hàm xử lý sự kiện focus
     *
     */
    onFocus() {
      this.$el.querySelector(".input").select(); // khi focus thì select
    },
  },
  created() {
    // this.placeholder = this.label;
  },
  watch: {
    Filter: function (value) {
      this.filter = value
      console.log(value);
    },
    items: function (value) {
      // nhận mảng item để hiển thị
      this.dataItems = value;
    },
    value: function (vl) {
      this.keyword = vl;
    },

    keyword() {
      if (this.keyword != this.currentItem[this.fieldName]) {
        // this.isShowCbb = true;
      } else if (this.keyword) {
        // this.isShowCbb=!this.isShowCbb
        this.dataItems.forEach((item) => {
          let valueSearch = item[this.fieldName].trim().toLowerCase();
          if (valueSearch.includes(this.keyword.trim().toLowerCase())) {
            return item;
          }
        });
      } else {
        this.dataItems = this.items;
      }
    },
  },
  mounted() {
    // xét giá trị ban đầu cho combobox
    this.currentItem[this.fieldName] = this.code;

    // this.item.filter((item,index)=>{
    //   if(item[this.fieldCode]===this.currentItem[this.fieldCode]){
    //     this.i=index
    //   }
    // })
  },
};
</script>
  
<style scoped>
@import url(../../css/base/combobox.css);

.borderRed {
  border-color: #e03232 !important;
}

.m-combobox-2 .drop-down .drop-down-body {
  max-height: 110px;
  height: -moz-fit-content;
  height: fit-content;
  overflow: auto;
  overflow-x: hidden;
}

.icon-tick {
  width: 8px;
}

.m-combobox-2 .input {
  padding: 0 20px 0 32px;
  width: 230px;
  margin-top: 0px;
  height: 36px;
  box-sizing: border-box;
  border-radius: 2.5px;
}

.m-combobox .icon {
  position: absolute;
  left: 6px;
  top: 50%;
  transform: translateY(-50%);
  cursor: pointer;

}

.m-combobox .up-down {
  position: absolute;
  right: 19px;
  top: 50%;
  transform: translateY(-50%);
  justify-content: center;
}
</style>
  