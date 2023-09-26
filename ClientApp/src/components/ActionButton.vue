<script setup lang="ts">
import { computed } from "vue";
import ButtonTypesEnum from "../modules/enums/buttonTypesEnum";

const props = defineProps({
  buttosnType: {
    type: String,
    required: false,
    default: ButtonTypesEnum.AcceptButton,
  },
  id: {
    type: String,
    required: false,
    default: "",
  },
});

const emit = defineEmits<{ (e: "action"): void }>();

const getDesign = computed(() => {
  switch (props.buttosnType) {
    case ButtonTypesEnum.AcceptButton:
      return "!bg-green-300 !hover:bg-green-400";
    case ButtonTypesEnum.CancelButton:
      return "!bg-red-300 !hover:bg-red-400";
    case ButtonTypesEnum.EditButton:
      return "!bg-orange-300 !hover:bg-orange-400";
    default:
      return "!bg-slate-300 !hover:bg-slate-400";
  }
});

const onButtonClick = () => {
  emit("action");
};
</script>

<template>
  <label
    :for="id"
    class="w-full h-full flex flex-row items-center justify-center rounded"
    :class="[getDesign]"
    @click="onButtonClick"
  >
    <p>
      <slot> Button </slot>
    </p>
    <input class="hidden w-full h-full" type="submit" value="" :id="id" />
  </label>
</template>
