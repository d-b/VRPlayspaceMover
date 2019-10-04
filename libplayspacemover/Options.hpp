#pragma once

namespace PlayspaceMover
{
	struct Options {
		uint64_t leftButtonMask = 130;
		uint64_t rightButtonMask = 130;
		uint64_t leftTogglePhysicsMask = 0;
		uint64_t rightTogglePhysicsMask = 0;
		uint64_t resetButtonMask = 0;
		float bodyHeight = 2;
	};
}
